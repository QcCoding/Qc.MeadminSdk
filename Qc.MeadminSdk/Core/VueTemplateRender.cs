using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Qc.MeadminSdk
{
    public static class VueTemplateRender
    {
        /// <summary>
        /// 模块开始标记
        /// </summary>
        public const string TemplateStart = "<template>";
        /// <summary>
        /// 模板内容匹配正则
        /// </summary>
        public const string TemplateRegexPattern = TemplateStart + @"([\S\s]*)" + TemplateEnd;
        /// <summary>
        /// 模板介绍标记
        /// </summary>
        public const string TemplateEnd = "</template>";
        /// <summary>
        /// Js开始标记
        /// </summary>
        public const string ScriptStart = "<script>";
        /// <summary>
        /// 脚本内容匹配正则
        /// </summary>
        public static string ScriptRegexPattern = ScriptStart + @"[\S\s]*?export[\S\s]+?default[\S\s]*?{([\S\s]*)}[\S\s]*?" + ScriptEnd;
        /// <summary>
        /// Js结束标记
        /// </summary>
        public const string ScriptEnd = "</script>";
        /// <summary>
        /// 路由下级参数分隔符 /:id
        /// </summary>
        public const string RouterChildrenParamsSeparator = ".";
        /// <summary>
        /// 路由同级参数分隔符 :id
        /// </summary>
        public const string RouterParamsSeparator = "_";

        /// <summary>
        /// 获取Vue 模板字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isRegex"></param>
        /// <returns></returns>
        public static string GetVueTemplate(string input, bool isRegex = true)
        {
            if (isRegex)
            {
                var regex = new Regex(VueTemplateRender.TemplateRegexPattern);
                return regex.Match(input)?.Groups[1].Value;
            }
            else
            {
                var templateFirstIndex = input.LastIndexOf(VueTemplateRender.TemplateStart);
                var templateLastIndex = input.LastIndexOf(VueTemplateRender.TemplateEnd);
                var template = input.Substring(templateFirstIndex + VueTemplateRender.TemplateStart.Length, templateLastIndex - templateFirstIndex - VueTemplateRender.TemplateStart.Length);
                return template;
            }
        }
        /// <summary>
        /// 获取Vue-脚本代码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isRegex"></param>
        /// <returns></returns>
        public static string GetVueScript(string input, bool isRegex = true)
        {
            if (isRegex)
            {
                var regex = new Regex(VueTemplateRender.ScriptRegexPattern);
                return regex.Match(input)?.Groups[1].Value;
            }
            else
            {
                //export default 处理
                var scriptFirstIndex = input.LastIndexOf(VueTemplateRender.ScriptStart);
                var scriptLastIndex = input.LastIndexOf(VueTemplateRender.ScriptEnd);
                var script = input.Substring(scriptFirstIndex + VueTemplateRender.ScriptStart.Length, scriptLastIndex - scriptFirstIndex - VueTemplateRender.ScriptStart.Length);

                return script;
            }
        }

        /// <summary>
        /// 解析 Vue 路由
        /// </summary>
        public static string AnalysisVue(string viewPath, string path, bool isRouter = true)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                var vueHtml = sr.ReadToEnd();
                // 无法解析@符号
                var templateUglifyResult = Uglify.Html(VueTemplateRender.GetVueTemplate(vueHtml).Replace(" @", " v-on:"), new NUglify.Html.HtmlSettings()
                {
                    RemoveQuotedAttributes = false,
                    AttributeQuoteChar = '\"',
                    RemoveScriptStyleTypeAttribute = false,
                    ShortBooleanAttribute = false,
                    IsFragmentOnly = true,
                    RemoveOptionalTags = false,
                    AttributesCaseSensitive = true
                    //RemoveComments = true,
                    //RemoveJavaScript = false,
                    //MinifyJs = false,
                    //MinifyCss = false,
                    //MinifyCssAttributes = false,
                });
                if (templateUglifyResult.HasErrors)
                {
                    throw new Exception(string.Join(",", templateUglifyResult.Errors));
                }
                var scriptUglifyResult = Uglify.Js(VueTemplateRender.GetVueScript(vueHtml, false), new NUglify.JavaScript.CodeSettings() { });
                if (scriptUglifyResult.HasErrors && scriptUglifyResult.Errors.Where(s => !s.Message.StartsWith("Implicit property name must be identifier")).Count() > 0)
                {
                    throw new Exception(string.Join(",", scriptUglifyResult.Errors));
                }
                var script = scriptUglifyResult.Code.Replace("export default{", "");
                var template = templateUglifyResult.Code;
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
                var str = template.Trim().Replace("'", "#&#");

                rb.Append("template:'" + str + "'.replace(/#&#/g,'\\''), " + script);


                //rb.Append("}");
                if (isRouter)
                {
                    rb.Append("}");
                }
                return rb.ToString();
            }
        }
    }
}
