using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// 模块描述,用于生成模块
    /// </summary>
    public class MeadminModuleAttribute : Attribute
    {
        public int Order { get; set; }
        public string ModuleName { get; set; }
        public string IconName { get; set; }
    }
}
