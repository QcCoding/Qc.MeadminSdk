using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// 系统信息模型
    /// </summary>
    public class SystemInfoModel
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
        public List<BackendMenuModel> Menus { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string Modules { get; set; }
    }
}
