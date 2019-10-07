using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk.Models
{
    /// <summary>
    /// 系统模块模型
    /// </summary>
    public class MeadminModuleModel
    {
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public List<MeadminPageModel> ModuleList { get; set; }
    }
}
