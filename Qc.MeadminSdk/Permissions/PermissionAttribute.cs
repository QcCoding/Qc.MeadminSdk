using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    public class PermissionAttribute : Attribute//, IFilterMetadata
    {
        public string ModuleCode { get; set; }
        public bool IsPage { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public PermissionAttribute(string code, string moduleName = null, bool isPage = false, string moduleIcon = null)
        {
            ModuleCode = code;
            IsPage = isPage;
            ModuleName = moduleName ?? code;
            ModuleIcon = moduleIcon;
        }
    }
}
