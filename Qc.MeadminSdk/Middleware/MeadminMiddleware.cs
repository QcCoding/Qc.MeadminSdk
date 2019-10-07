using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Qc.MeadminSdk.Models;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// MeadminMiddleware
    /// </summary>
    public class MeadminMiddleware
    {
        private const string EmbeddedFileNamespace = "Qc.MeadminSdk.jslibs";
        private readonly MeadminOptions _options;
        private readonly StaticFileMiddleware _staticFileMiddleware;
        private readonly RequestDelegate _next;
        public MeadminMiddleware(
            RequestDelegate next,
            IOptions<MeadminOptions> options,
            IHostingEnvironment hostingEnv,
            ILoggerFactory loggerFactory)
        {
            _options = options.Value;
            _next = next;
            _staticFileMiddleware = CreateStaticFileMiddleware(next, hostingEnv, loggerFactory);
        }
        MeadminSystemInfoModel _systemInfo;
        public async Task Invoke(HttpContext httpContext)
        {
            var httpMethod = httpContext.Request.Method.ToUpper();
            var path = httpContext.Request.Path.Value;
            var routePrefix = _options.RoutePrefix;
            var _method = httpContext.Request.Method.ToLower();
            var _path = httpContext.Request.PathBase.Value + httpContext.Request.Path.Value;
            var _routePrefix = _options.RoutePrefix ?? string.Empty;
            if (httpMethod != "GET" || path.StartsWith($"/{routePrefix}") == false || path == _options.LoginPath)
            {
                await _next(httpContext);
                return;
            }
            _systemInfo = _options.AuthHandler(httpContext);
            if (_systemInfo == null || string.IsNullOrEmpty(_systemInfo.AuthName) || string.IsNullOrEmpty(_systemInfo.Modules))
            {
                await httpContext.Response.WriteAsync("Unauthorized Access");
                return;
            }
            else if (path == $"/{routePrefix}")
            {
                string location = string.IsNullOrEmpty(routePrefix) ? "/index.html" : $"/{routePrefix}/";
                RespondWithRedirect(httpContext.Response, location);
                return;
            }
            else if (string.IsNullOrEmpty(routePrefix) ? (path == "/" || path == "/index.html") : (path == $"/{routePrefix}/" || path == $"/{routePrefix}/index.html"))
            {
                await RespondWithHtml(httpContext.Response, "index.html");
                return;
            }
            else if (path == $"{routePrefix}/build.js" || path == $"/{routePrefix}/build.js")
            {
                await RespondWithBuildJs(httpContext.Response);
                return;
            }
            else if (_options.EnableModuleLazyload && path.StartsWith($"{routePrefix}/modulejs/") || path.StartsWith($"/{routePrefix}/modulejs/"))
            {
                var m = path.Replace($"/{routePrefix}/modulejs/", "").Replace($"{routePrefix}/modulejs/", "").Replace(".js", "");
                await RespondWithModulesJs(httpContext.Response, m);
                return;
            }

            await _staticFileMiddleware.Invoke(httpContext);
        }

        private StaticFileMiddleware CreateStaticFileMiddleware(
            RequestDelegate next,
            IHostingEnvironment hostingEnv,
            ILoggerFactory loggerFactory)
        {
            var staticFileOptions = new StaticFileOptions
            {
                RequestPath = string.IsNullOrEmpty(_options.RoutePrefix) ? string.Empty : $"/{_options.RoutePrefix}",
                FileProvider = new EmbeddedFileProvider(typeof(MeadminOptions).GetTypeInfo().Assembly, EmbeddedFileNamespace),
            };

            return new StaticFileMiddleware(next, hostingEnv, Options.Create(staticFileOptions), loggerFactory);
        }
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="response"></param>
        /// <param name="location"></param>
        private void RespondWithRedirect(HttpResponse response, string location)
        {
            response.StatusCode = 301;
            response.Headers["Location"] = location;
        }
        /// <summary>
        /// 输出首页
        /// </summary>
        /// <param name="response"></param>
        /// <param name="assetsName"></param>
        /// <returns></returns>
        private async Task RespondWithHtml(HttpResponse response, string assetsName)
        {
            response.StatusCode = 200;
            response.ContentType = "text/html;charset=utf-8";

            using (var stream = typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.{assetsName}"))
            {
                var htmlBuilder = new StringBuilder(new StreamReader(stream).ReadToEnd());
                htmlBuilder.Replace("{{SysTitle}}", _options.GetPageConfig()[MeadminPageConst.SysTitle].ToString());
                htmlBuilder.Replace("{{SysMainJsSrc}}", !string.IsNullOrEmpty(_options.CustomMainJsSrc) ? _options.CustomMainJsSrc : (_options.EnableModuleLazyload ? "./main_modules.js" : "./main.js"));
                htmlBuilder.Replace("<tmp-head></tmp-head>", string.Join(Environment.NewLine, _options.HeaderTemplate));
                htmlBuilder.Replace("<tmp-footer></tmp-footer>", string.Join(Environment.NewLine, _options.FooterTemplate));

                await response.WriteAsync(htmlBuilder.ToString(), Encoding.UTF8);
            }
        }
        private async Task RespondWithModulesJs(HttpResponse response, string modules)
        {
            var viewFiles = Directory.GetFiles(_options.ViewPath + "/" + modules, "*.vue", SearchOption.AllDirectories).ToList();
            List<string> routers = new List<string>();
            List<string> components = new List<string>();
            foreach (var item in viewFiles)
            {
                if (item.EndsWith("Comp.vue"))
                {
                    var component = AnalysisVue(_options.ViewPath, item, false);
                    components.Add(component);
                }
                var router = AnalysisVue(_options.ViewPath, item);
                routers.Add(router);
            }
            var componentContent = "window.ModulesComps_" + modules + "=[" + string.Join(",", components) + "];";
            var routerContent = "window.ModulesRoutes_" + modules + "=[" + string.Join(",", routers) + "];";
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine(componentContent);
            contentBuilder.AppendLine(routerContent);
            await response.WriteAsync(contentBuilder.ToString(), Encoding.UTF8);
        }
        /// <summary>
        /// 输出buildjs,包含组件及扩展的js
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task RespondWithBuildJs(HttpResponse response)
        {
            response.StatusCode = 200;
            response.ContentType = "text/javascript;charset=utf-8";

            using (var stream = typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.build.js"))
            {
                // Inject arguments before writing to response
                var jsBuilder = new StringBuilder(new StreamReader(stream).ReadToEnd());
                foreach (var entry in GetBuildArguments())
                {
                    jsBuilder.Replace(entry.Key, entry.Value);
                }
                jsBuilder.AppendLine(GetAppendJs());

                await response.WriteAsync(jsBuilder.ToString(), Encoding.UTF8);
            }
        }
        private IDictionary<string, string> GetBuildArguments()
        {
            var systemRoutes = string.Join(",", GetRoutes());
            var systemComps = string.Join(",", GetComponents());
            Dictionary<string, object> systemInfo = _options.GetPageConfig();
            systemInfo.Add("AuthName", _systemInfo.AuthName);
            systemInfo.Add("Menus", _systemInfo.Menus);
            systemInfo.Add("Modules", _systemInfo.Modules);
            return new Dictionary<string, string>()
            {
                { "_Data_SystemInfo",JsonHelper.Serialize(systemInfo) },
                { "_Data_SystemRoutes",JsonHelper.Serialize(systemRoutes) },
                { "_Data_SystemComps",JsonHelper.Serialize(systemComps) },
            };
        }
        private string GetAppendJs()
        {
            if (_options.AppendJsPaths == null || _options.AppendJsPaths.Count == 0)
                return string.Empty;
            StringBuilder builder = new StringBuilder();
            foreach (var item in _options.AppendJsPaths)
            {
                builder.AppendLine(File.ReadAllText(item));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 获取顶层路由信息
        /// </summary>
        /// <returns></returns>
        private List<string> GetRoutes()
        {
            var viewFiles = Directory.GetFiles(_options.ViewPath, "*.vue", _options.EnableModuleLazyload ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories).Where(s => !s.EndsWith("Comp.vue")).ToList();
            List<string> routers = new List<string>();
            foreach (var item in viewFiles)
            {
                var router = AnalysisVue(_options.ViewPath, item);
                routers.Add(router);
            }
            return routers;
        }
        /// <summary>
        /// 获取组件信息
        /// </summary>
        /// <returns></returns>
        private List<string> GetComponents()
        {
            var viewFiles = Directory.GetFiles(_options.ViewPath, "*.vue", _options.EnableModuleLazyload ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories).Where(s => s.EndsWith("Comp.vue")).ToList();
            List<string> components = new List<string>();
            foreach (var item in viewFiles)
            {
                var component = AnalysisVue(_options.ViewPath, item, false);
                components.Add(component);
            }
            return components;
        }

        /// <summary>
        /// 解析 Vue 路由
        /// </summary>
        private string AnalysisVue(string viewPath, string path, bool isRouter = true)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                var vueHtml = sr.ReadToEnd();
                string template = VueTemplateRender.GetVueTemplate(vueHtml).Replace("\\", "\\\\");
                string script = VueTemplateRender.GetVueScript(vueHtml);
                var routerPath = path.Replace(viewPath, "")
                    .Replace("//", "/")
                    .Replace("\\", "/")
                    .Replace(".vue", "")
                    .Replace(VueTemplateRender.RouterChildrenParamsSeparator, "/:")
                    .Replace(VueTemplateRender.RouterParamsSeparator, ":");
                var rb = new StringBuilder();
                if (isRouter)
                {

                    rb.Append("{");
                    rb.Append("path: '" + routerPath + "',");
                    rb.Append("component: ");
                }
                rb.Append("{ ");
                string newLine = _options.IsUseCustomNewLine ? "\r\n" : Environment.NewLine;

                template = Regex.Replace(template, @"(" + newLine + ")+", newLine);
                var str = template.Trim().Replace("'", "#&#").Replace(newLine, "\\");
                rb.Append("template:'" + str + "'.replace(/#&#/g,'\\''), " + script);


                rb.Append("}");
                if (isRouter)
                {
                    rb.Append("}");
                }
                return rb.ToString();
            }
        }
    }
}
