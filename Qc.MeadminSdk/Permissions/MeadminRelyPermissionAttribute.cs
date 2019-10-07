using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// 依赖权限
    /// </summary>
    public class MeadminRelyPermissionAttribute : Attribute //, IFilterMetadata
    {
        public List<string> Codes { get; set; }
        public MeadminRelyPermissionAttribute(params string[] codes)
        {
            Codes = codes.ToList();
        }
    }
}
