using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    public class MeadminOptions
    {

        /// <summary>
        /// 视图路径
        /// </summary>
        public string ViewPath { get; set; }
        /// <summary>
        /// 追加的js文件路径
        /// </summary>
        public List<string> AppendJsPaths { get; set; }
        /// <summary>
        /// 接口基础前缀
        /// </summary>
        public string ApiBasePrefix { get; set; }
        /// <summary>
        /// 路由前缀
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// 系统标题
        /// </summary>
        public string SysTitle { get; set; }
        /// <summary>
        /// 系统Logo 暂未使用
        /// </summary>
        public string SysLogo { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        public string SysTheme { get; set; }
        /// <summary>
        /// 左侧导航主题
        /// </summary>
        public Dictionary<string, object> SysNavTheme { get; set; }
        /// <summary>
        /// 首页Url
        /// </summary>
        public string IndexPath { get; set; }
        /// <summary>
        /// 登录提交接口地址
        /// </summary>
        public string LoginApiPath { get; set; }
        /// <summary>
        /// 登录Url
        /// </summary>
        public string LoginPath { get; set; }
        /// <summary>
        /// 退出url
        /// </summary>
        public string LogoutPath { get; set; }
        /// <summary>
        /// 通用地图Key
        /// </summary>
        public string CommonAmapKey { get; set; }
        /// <summary>
        /// 头部模板，加载自定义字体css等
        /// </summary>
        public List<string> HeaderTemplate { get; set; }
        /// <summary>
        /// 底部模板，加载自定义js
        /// </summary>
        public List<string> FooterTemplate { get; set; }
        /// <summary>
        /// 使用自定义换行符 linux的行为不一致 true：Environment.NewLine，false：\r\n
        /// </summary>
        public bool IsUseCustomNewLine { get; set; }
        /// <summary>
        /// 真实的登录地址
        /// </summary>
        internal string RealyLoginPath
        {
            get
            {
                if (string.IsNullOrEmpty(LoginPath))
                    return string.IsNullOrEmpty(RoutePrefix) ? "" : ("/" + RoutePrefix) + "/start.html";
                return LoginPath;
            }
        }
        /// <summary>
        /// 启用模块懒加载
        /// </summary>
        public bool EnableModuleLazyload { get; set; }
        /// <summary>
        /// 自定义main.js的src
        /// </summary>
        public string CustomMainJsSrc { get; set; }
    }
}
