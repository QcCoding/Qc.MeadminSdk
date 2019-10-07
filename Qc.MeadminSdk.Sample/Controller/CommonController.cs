using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qc.MeadminSdk.Models;

namespace Qc.MeadminSdk.Sample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        /// <summary>
        /// 桌面信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("home")]
        [MeadminPermission("home", "控制台", true)]
        public IActionResult Home()
        {
            return Ok();
        }
        /// <summary>
        /// 获取当天新增信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dayinfo")]
        [MeadminRelyPermission("home")]
        public IActionResult GetDayAddedInfo()
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            dics.Add("新增会员", "33");
            dics.Add("新增订单", "666");
            dics.Add("成交金额", "￥999");
            dics.Add("客单价格", "￥999");
            return Ok(OperateResult.Succeed("ok", dics));
        }

        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("envinfo")]
        [MeadminRelyPermission("home")]
        public IActionResult GetEnvironmentInfo()
        {
            List<KeyValuePair<string, object>> infoList = new List<KeyValuePair<string, object>>();
            infoList.Add(new KeyValuePair<string, object>("操作系统", global::System.Runtime.InteropServices.RuntimeInformation.OSDescription));
            infoList.Add(new KeyValuePair<string, object>("系统架构", global::System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString()));
            infoList.Add(new KeyValuePair<string, object>("进程架构", global::System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString()));
            infoList.Add(new KeyValuePair<string, object>("框架", global::System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription));
            infoList.Add(new KeyValuePair<string, object>("服务器时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));

            return Ok(OperateResult.Succeed("ok", infoList));
        }
        /// <summary>
        /// 图片上传（File/Base64）二选一
        /// </summary>
        /// <param name="file">文件域</param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult Upload(IFormFile file)
        {
            var stream = file.OpenReadStream();
            stream.Position = 0;
            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            var saveDir = "./wwwroot/upload/";
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            using (var fs = new FileStream(saveDir + fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                stream.CopyTo(fs);
                if (stream.CanRead)
                {
                    stream.Dispose();
                }
            }
            var filePath = "/upload/" + fileName;
            return Ok(OperateResult.Succeed("ok", filePath));
        }
    }
}
