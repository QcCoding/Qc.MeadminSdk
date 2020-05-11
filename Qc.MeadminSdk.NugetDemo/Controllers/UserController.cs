using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qc.MeadminSdk.Models;

namespace Qc.MeadminSdk.NugetDemo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [MeadminModule(Order = 200, ModuleName = "用户管理")]
    public class UserController : ControllerBase
    {
        static List<UserInfoModel> USER_LIST_DATA = null;
        public UserController()
        {
            InitListData();
        }
        void InitListData()
        {
            if (USER_LIST_DATA != null)
                return;
            USER_LIST_DATA = new List<UserInfoModel>();
            for (int i = 1; i <= 188; i++)
            {
                USER_LIST_DATA.Add(new UserInfoModel()
                {
                    Id = i,
                    Username = "test___" + i,
                    NickName = "用户___" + i,
                    IsBlack = new Random().Next(1, 100) % 3 == 0,
                    CreatedAt = DateTime.Now
                });
            }
        }
        #region 用户管理

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/list")]
        [MeadminPermission("user_user_list", "用户列表", true)]
        public IActionResult UserList(string keyword, int pageIndex = 0, int pageSize = 20)
        {
            var items = USER_LIST_DATA;
            if (!string.IsNullOrEmpty(keyword))
            {
                items = items.Where(s => s.Username.Contains(keyword) || (string.IsNullOrEmpty(s.NickName) || s.NickName.Contains(keyword))).ToList();
            }
            var count = items.Count();
            items = items.OrderByDescending(s => s.CreatedAt)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToList();
            return Ok(OperateResult.Succeed("ok", new
            {
                Items = items,
                TotalCount = count
            }));
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/item")]
        [MeadminRelyPermission("user_user_create", "user_user_edit")]
        public IActionResult UserItem(int id)
        {
            var existItem = USER_LIST_DATA.FirstOrDefault(s => s.Id == id);
            return Ok(existItem == null ? OperateResult.Error("用户不存在") : OperateResult.Succeed("ok", existItem));
        }
        /// <summary>
        /// 用户创建
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("user/create")]
        [MeadminPermission("user_user_create", "用户创建")]
        //[ModelValid]
        public OperateResult UserCreate([FromBody]UserInfoModel input)
        {
            if (string.IsNullOrEmpty(input?.Username))
                return OperateResult.Error("用户名不能为空");

            input.CreatedAt = DateTime.Now;
            USER_LIST_DATA.Add(input);
            var result = OperateResult.Succeed("保存成功");
            return result;
        }
        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("user/edit")]
        [MeadminPermission("user_user_edit", "用户编辑")]
        //[ModelValid]
        public OperateResult UserEdit([FromBody]UserInfoModel input)
        {
            if (string.IsNullOrEmpty(input?.Username))
                return OperateResult.Error("用户名不能为空");
            var existItem = USER_LIST_DATA.FirstOrDefault(s => s.Id == input.Id);
            if (existItem == null)
            {
                return OperateResult.Error("用户不存在");
            }
            existItem.Avatar = input.Avatar;
            existItem.Username = input.Username;
            existItem.NickName = input.NickName;
            existItem.IsBlack = input.IsBlack;

            var result = OperateResult.Succeed("保存成功");
            return result;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("user/delete")]
        [MeadminPermission("user_user_delete", "用户删除")]
        public IActionResult DeleteUser([FromBody]IdsRequest<long> request)
        {
            USER_LIST_DATA.RemoveAll(s => request.Ids.Contains(s.Id));
            var result = OperateResult.Succeed("删除成功");
            return Ok(result);
        }
        #endregion
    }
    /// <summary>
    /// 通用request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IdsRequest<T>
    {
        public List<T> Ids { get; set; }
    }
    public class UserInfoModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string NickName { get; set; }
        public bool IsBlack { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
