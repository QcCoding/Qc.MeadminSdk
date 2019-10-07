using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk.Models
{

    /// <summary>
    /// 系统页面模型
    /// </summary>
    public class MeadminPageModel
    {
        public MeadminPageModel(string moduleName, string moduleCode, bool isPage, string moduleIcon)
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
}
