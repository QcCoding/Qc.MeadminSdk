using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk.Models
{

    /// <summary>
    /// 系统信息模型
    /// </summary>
    public class MeadminSystemInfoModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string AuthName { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public List<string> IconList { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public List<MeadminMenuModel> Menus { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string Modules { get; set; }
    }
}
