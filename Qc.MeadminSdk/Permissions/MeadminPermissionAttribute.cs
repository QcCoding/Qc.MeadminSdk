using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    public class MeadminPermissionAttribute : Attribute//, IFilterMetadata
    {
        public string ModuleCode { get; set; }
        public bool IsPage { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public MeadminPermissionAttribute(string code, string moduleName = null, bool isPage = false, string moduleIcon = null)
        {
            ModuleCode = code;
            IsPage = isPage;
            ModuleName = moduleName ?? code;
            ModuleIcon = moduleIcon;
        }
    }
}
