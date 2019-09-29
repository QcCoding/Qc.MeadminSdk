using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk.Models
{
    public class OperateResult
    {
        public OperateResult(ResultStatus status, string msg, object data = null)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }
        /// <summary>
        /// 请求状态 Error = 0, Succeed = 1
        /// </summary>
        public ResultStatus Status { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
        public static OperateResult Succeed(string msg, object data = null)
        {
            return new OperateResult(ResultStatus.Succeed, msg, data);
        }
        public static OperateResult Error(string msg)
        {
            return new OperateResult(ResultStatus.Error, msg);
        }
    }
    public enum ResultStatus
    {
        Error = 0,
        Succeed = 1
    }
}
