using Microsoft.AspNetCore.Http;
using Qc.MeadminSdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// 框架配置常量
    /// </summary>
    public class MeadminPageConst
    {
        /// <summary>
        /// 接口前缀
        /// </summary>
        public const string ApiBasePrefix = nameof(ApiBasePrefix);
        /// <summary>
        /// 系统标题
        /// </summary>
        public const string SysTitle = nameof(SysTitle);
        /// <summary>
        /// Logo
        /// </summary>
        public const string SysLogo = nameof(SysLogo);
        /// <summary>
        /// 系统主题
        /// </summary>
        public const string SysTheme = nameof(SysTheme);
        /// <summary>
        /// 自定义main.js
        /// </summary>
        public const string SysMainJsSrc = nameof(SysMainJsSrc);
        /// <summary>
        /// 登录路径
        /// </summary>
        public static string LoginPath = nameof(LoginPath);
        /// <summary>
        /// 退出路径
        /// </summary>
        public static string LogoutPath = nameof(LogoutPath);
        /// <summary>
        /// 首页路径
        /// </summary>
        public static string IndexPath = nameof(IndexPath);
        /// <summary>
        /// 侧栏皮肤
        /// </summary>
        public static string SysNavTheme = nameof(SysNavTheme);
    }
    /// <summary>
    /// Meadmin配置
    /// </summary>
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
        /// 首页Url
        /// </summary>
        public string IndexPath { get; set; }
        /// <summary>
        /// 路由前缀
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// 左侧导航主题
        /// </summary>
        public Dictionary<string, object> SysNavTheme { get; set; }

        /// <summary>
        /// 登录Url
        /// </summary>
        public string LoginPath { get; set; }
        /// <summary>
        /// 退出url
        /// </summary>
        public string LogoutPath { get; set; }
        /// <summary>
        /// 系统标题
        /// </summary>
        public string SysTitle { get; set; }
        /// <summary>
        /// 接口前缀
        /// </summary>
        public string ApiBasePrefix { get; set; }
        /// <summary>
        /// 自定义mainjs路径
        /// </summary>
        public string SysMainJsSrc { get; set; }
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
        /// 启用模块懒加载
        /// </summary>
        public bool EnableModuleLazyload { get; set; }
        /// <summary>
        /// 启用 Babel
        /// </summary>
        public bool EnableBabel { get; set; }
        /// <summary>
        /// 自定义main.js的src
        /// </summary>
        public string CustomMainJsSrc { get; set; }
        /// <summary>
        /// 页面文案配置
        /// </summary>
        public Dictionary<string, object> PageSetting { get; set; }
        /// <summary>
        /// 获取页面配置
        /// </summary>
        /// <returns></returns>
        internal Dictionary<string, object> GetPageConfig()
        {
            var dic = new Dictionary<string, object>()
            {
                {MeadminPageConst.SysTitle,SysTitle },
                {MeadminPageConst.ApiBasePrefix,ApiBasePrefix },
                {MeadminPageConst.SysMainJsSrc,SysMainJsSrc },
                {MeadminPageConst.LoginPath,LoginPath},
                {MeadminPageConst.LogoutPath,LogoutPath},
                {MeadminPageConst.IndexPath,IndexPath},
                {MeadminPageConst.SysNavTheme,SysNavTheme},
            };
            if (PageSetting?.Count > 0)
            {
                foreach (var item in PageSetting)
                {
                    if (dic.ContainsKey(item.Key))
                    {
                        dic[item.Key] = item.Value;
                    }
                    else
                    {
                        dic.Add(item.Key, item.Value);
                    }
                }
            }
            return dic;
        }
        /// <summary>
        /// 系统登录信息
        /// </summary>
        public Func<HttpContext, MeadminSystemInfoModel> AuthHandler { get; set; }
    }
}
