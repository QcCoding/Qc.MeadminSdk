using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Qc.MeadminSdk
{
    public class CustomBackendModuleModel
    {
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public List<BackendModuleModel> ModuleList { get; set; }
    }
    public class BackendModuleModel
    {
        public BackendModuleModel(string moduleName, string moduleCode, bool isPage, string moduleIcon)
        {
            ModuleName = moduleName;
            ModuleCode = moduleCode;
            IsPage = isPage;
            ModuleIcon = moduleIcon;
        }

        public string ModuleCode { get; set; }
        public bool IsPage { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
    }
    /// <summary>
    /// 系统菜单模型
    /// </summary>
    public class BackendMenuModel
    {
        public BackendMenuModel()
        {
            MenuId = Guid.NewGuid().ToString("N");
        }
        public BackendMenuModel(BackendModuleModel model)
        {
            MenuName = model.ModuleName;
            MenuCode = model.ModuleCode;
            MenuIcon = model.ModuleIcon;
            MenuId = Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 菜单Id
        /// </summary>
        public string MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string MenuUrl { get; set; }
        /// <summary>
        /// 下级菜单
        /// </summary>
        public List<BackendMenuModel> Children { get; set; }
    }
}
