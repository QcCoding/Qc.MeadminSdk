﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qc.MeadminSdk
{
    /// <summary>
    /// 依赖权限
    /// </summary>
    public class RelyPermissionAttribute : Attribute //, IFilterMetadata
    {
        public List<string> Codes { get; set; }
        public RelyPermissionAttribute(params string[] codes)
        {
            Codes = codes.ToList();
        }
    }
}
