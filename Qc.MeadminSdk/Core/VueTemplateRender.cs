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
        public static string ScriptRegexPattern = ScriptStart + @"[\S\s]*?{([\S\s]*)}[\S\s]*?" + ScriptEnd;
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
        /// <returns></returns>
        public static string GetVueScript(string input)
        {
            var regex = new Regex(VueTemplateRender.ScriptRegexPattern);
            return regex.Match(input)?.Groups[1].Value.Trim();
        }

        /// <summary>
        /// 解析 Vue 路由
        /// </summary>
        public static string AnalysisVue(string viewPath, string path, bool isRouter = true)
        {
            using (StreamReader sr = new StreamReader(path))
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
                });
                if (templateUglifyResult.HasErrors)
                {
                    throw new Exception(string.Join(",", templateUglifyResult.Errors));
                }
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
                    rb.AppendLine("{");
                    rb.AppendLine("path: '" + routerPath + "',");
                    rb.AppendLine("component: ");
                }
                // 模板字符串，序列化一下自动转义
                var templateStr = JsonHelper.Serialize(template);
                //解析js
                var scriptStr = GetVueScript(vueHtml);// path:'',created(){}
                rb.AppendLine("{template:" + templateStr + "," + scriptStr + "}");

                if (isRouter)
                {
                    rb.AppendLine("}");
                }
                return rb.ToString();
            }
        }
    }
}
