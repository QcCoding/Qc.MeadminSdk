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
using NUglify;

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
            if (httpMethod != "GET" || path.StartsWith($"/{routePrefix}") == false || path == _options.LoginPath)
            {
                await _next(httpContext);
                return;
            }
            _systemInfo = _options.AuthHandler(httpContext);
            if (_systemInfo == null || string.IsNullOrEmpty(_systemInfo.Modules))
            {
                await httpContext.Response.WriteAsync("Unauthorized Access");
                return;
            }
            if (string.IsNullOrEmpty(routePrefix) ? (path == "/" || path == "/index.html") : (path == $"/{routePrefix}/" || path == $"/{routePrefix}/index.html"))
            {
                await RespondWithIndexHtml(httpContext);
                return;
            }
            else if (path == $"{routePrefix}/build.js" || path == $"/{routePrefix}/build.js")
            {
                httpContext.Response.StatusCode = 200;
                httpContext.Response.ContentType = IsUseBabel(httpContext) ? "text/babel" : "text/javascript;charset=utf-8";
                await RespondWithBuildJs(httpContext);
                return;
            }
            else if (path == $"{routePrefix}/main.js" || path == $"/{routePrefix}/main.js")
            {
                using (StreamReader stream = new StreamReader(typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.main.js")))
                {
                    var jsContent = stream.ReadToEnd();
                    httpContext.Response.StatusCode = 200;
                    httpContext.Response.ContentType = IsUseBabel(httpContext) ? "text/babel" : "text/javascript;charset=utf-8";
                    await httpContext.Response.WriteAsync(UglifyJs(jsContent));
                }
                return;
            }
            else if (path == $"{routePrefix}/main_modules.js" || path == $"/{routePrefix}/main_modules.js")
            {
                using (StreamReader stream = new StreamReader(typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.main_modules.js")))
                {
                    var jsContent = stream.ReadToEnd();
                    httpContext.Response.StatusCode = 200;
                    httpContext.Response.ContentType = IsUseBabel(httpContext) ? "text/babel" : "text/javascript;charset=utf-8";
                    await httpContext.Response.WriteAsync(UglifyJs(jsContent));
                }
                return;
            }
            else if (_options.EnableModuleLazyload && path.StartsWith($"{routePrefix}/modulejs/") || path.StartsWith($"/{routePrefix}/modulejs/"))
            {
                var m = path.Replace($"/{routePrefix}/modulejs/", "").Replace($"{routePrefix}/modulejs/", "").Replace(".js", "");
                httpContext.Response.StatusCode = 200;
                httpContext.Response.ContentType = IsUseBabel(httpContext) ? "text/babel" : "text/javascript;charset=utf-8";
                await RespondWithModulesJs(httpContext.Response, m);
                return;
            }
            await _staticFileMiddleware.Invoke(httpContext);
            // hisotry 模式
            if (_options.IsHistoryMode && httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await RespondWithIndexHtml(httpContext);
            }
        }

        private StaticFileMiddleware CreateStaticFileMiddleware(
            RequestDelegate next,
            IHostingEnvironment hostingEnv,
            ILoggerFactory loggerFactory)
        {
            var staticFileOptions = new StaticFileOptions
            {
                RequestPath = string.IsNullOrEmpty(_options.RoutePrefix) ? string.Empty : $"/{_options.RoutePrefix}",
                FileProvider = new EmbeddedFileProvider(typeof(MeadminOptions).GetTypeInfo().Assembly, EmbeddedFileNamespace)
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
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private async Task RespondWithIndexHtml(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            var htmlBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(_options.CustomIndexHtml))
            {
                using (var stream = new StreamReader(typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.index.html")))
                {
                    htmlBuilder.Append(stream.ReadToEnd());
                }
            }
            else
            {
                htmlBuilder.Append(_options.CustomIndexHtml);
            }
            string sysRoutePrefix = string.IsNullOrEmpty(_options.RoutePrefix) ? "." : "/" + _options.RoutePrefix;
            var isUseBabel = IsUseBabel(httpContext);
            htmlBuilder.Replace("{{ScriptType}}", isUseBabel ? "text/babel" : "text/javascript");
            htmlBuilder.Replace("{{SysRoutePrefix}}", sysRoutePrefix);
            htmlBuilder.Replace("{{SysTitle}}", _options.GetPageConfig()[MeadminPageConst.SysTitle]?.ToString() ?? string.Empty);
            htmlBuilder.Replace("{{SysMainJsSrc}}", !string.IsNullOrEmpty(_options.CustomMainJsSrc) ? _options.CustomMainJsSrc : (sysRoutePrefix + (_options.EnableModuleLazyload ? "/main_modules.js" : "/main.js")));
            htmlBuilder.Replace("<tmp-head></tmp-head>", _options.HeaderTemplate == null ? string.Empty : string.Join(Environment.NewLine, _options.HeaderTemplate));
            htmlBuilder.Replace("<tmp-footer></tmp-footer>", _options.FooterTemplate == null ? string.Empty : string.Join(Environment.NewLine, _options.FooterTemplate));
            //babel
            htmlBuilder.Replace("<tmp-babel></tmp-babel>", !isUseBabel ? string.Empty : $@"<script type=""text/javascript"" src =""{sysRoutePrefix}/babel/babel.js"" ></script><script type=""text/javascript"" src =""{sysRoutePrefix}/polyfill/polyfill.js""></script>");
            await httpContext.Response.WriteAsync(UglifyHtml(htmlBuilder.ToString()));
        }
        /// <summary>
        /// 如果不是chrome/firefox则引用babel
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool IsUseBabel(HttpContext httpContext)
        {
            return _options.IsUseBabel || !Regex.IsMatch(httpContext.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.UserAgent], @"(Chrome|Firefox|iPhone)");
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

            await response.WriteAsync(UglifyJs(contentBuilder.ToString()));
        }
        /// <summary>
        /// 压缩JS
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string UglifyJs(string content)
        {
            return _options.EnableUglifyJs ? Uglify.Js(content, new NUglify.JavaScript.CodeSettings() { PreserveImportantComments = true }).Code : content;
        }
        /// <summary>
        /// 压缩html
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string UglifyHtml(string html)
        {
            return _options.EnableUglifyHtml ? Uglify.Html(html).Code : html;
        }
        /// <summary>
        /// <summary>
        /// 输出buildjs,包含组件及扩展的js
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private async Task RespondWithBuildJs(HttpContext httpContext)
        {

            using (var stream = new StreamReader(typeof(MeadminOptions).GetTypeInfo().Assembly.GetManifestResourceStream($"{EmbeddedFileNamespace}.build.js")))
            {
                // Inject arguments before writing to response
                var jsBuilder = new StringBuilder(stream.ReadToEnd());
                foreach (var entry in GetBuildArguments())
                {
                    jsBuilder.Replace(entry.Key, entry.Value);
                }
                jsBuilder.AppendLine(GetAppendJs());
                await httpContext.Response.WriteAsync(UglifyJs(jsBuilder.ToString()));
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
                { "__Data_RoutePrefix",JsonHelper.Serialize(_options.RoutePrefix) },
                { "__Data_IsHistoryMode",_options.IsHistoryMode ? "true" : "false" },
                { "__Data_SystemInfo",JsonHelper.Serialize(systemInfo) },
                { "__Data_SystemRoutes",systemRoutes },
                { "__Data_SystemComps",systemComps },
            };
        }
        /// <summary>
        /// 追加自定义js
        /// </summary>
        /// <returns></returns>
        private string GetAppendJs()
        {
            if (_options.AppendJsPaths == null || _options.AppendJsPaths.Count == 0)
                return string.Empty;
            StringBuilder builder = new StringBuilder();
            foreach (var item in _options.AppendJsPaths)
            {
                if (File.Exists(item))
                {
                    builder.AppendLine(File.ReadAllText(item));
                }
                else if (Directory.Exists(item))
                {
                    foreach (var item2 in Directory.GetFiles(item, "*.js", SearchOption.AllDirectories))
                    {
                        builder.AppendLine(File.ReadAllText(item2));
                    }
                }
            }
            return builder.ToString();
        }
        /// <summary>
        /// 获取路由信息
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
            return VueTemplateRender.AnalysisVue(viewPath, path, isRouter);
        }
    }
}
