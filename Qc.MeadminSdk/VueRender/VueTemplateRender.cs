using System;
using System.Collections.Generic;
using System.Linq;
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
                var scriptFirstIndex = input.LastIndexOf(VueTemplateRender.ScriptStart);
                var scriptLastIndex = input.LastIndexOf(VueTemplateRender.ScriptEnd);
                var script = input.Substring(scriptFirstIndex + VueTemplateRender.ScriptStart.Length, scriptLastIndex - scriptFirstIndex - VueTemplateRender.ScriptStart.Length);
                return script;
            }
        }
    }
}
