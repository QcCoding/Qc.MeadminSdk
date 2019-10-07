using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk.Models
{

    /// <summary>
    /// 系统菜单模型
    /// </summary>
    public class MeadminMenuModel
    {
        public MeadminMenuModel()
        {
            MenuId = Guid.NewGuid().ToString("N");
        }
        public MeadminMenuModel(MeadminPageModel model)
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
        public List<MeadminMenuModel> Children { get; set; }
    }
}
