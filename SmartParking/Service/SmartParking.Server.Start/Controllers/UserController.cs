using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Server.IConfiguration;
using SmartParking.Server.IService;
using SmartParking.Server.Models;
using SmartParking.Server.Service;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //依赖注入
        private IUtils utils;
        private ILoginService loginService;
        private IMenuService menuService;
        private IUserService userService;
        public UserController(IUtils utils,ILoginService loginService, IMenuService menuService,IUserService userService)
        {
            this.utils = utils;
            this.loginService = loginService;
            this.menuService = menuService;
            this.userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)//从表单获取
        {
            //密码加密
            string pwd = utils.GetMD5Str($"{utils.GetMD5Str(password)}|{username}");//双重加密
            var users = loginService.Query<SysUserInfo>(u => u.UserName == username && u.PassWord == pwd);
            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];
                //菜单
                //需要进行权限管理，需要5张表格进行管理
                //menu<->role_menu<->role<->role_user<->user
                List<MenuInfo> menus = menuService.GetMenusByUserId(sysUserInfo.UserId);
                sysUserInfo.Menus = menus;

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
            //return "{\"State\":\"True\"}";
        }

        [HttpGet]
        [Route("all")]
        public JsonResult GetUsers()
        {
            return Json(userService.Query<SysUserInfo>(u => true));
        }

        [HttpGet]
        [Route("roles/{userId}")]
        public JsonResult GetRolesByUserId(int userId)
        {
            return Json(userService.GetRolesByUserId(userId));
        }

        [HttpPost]
        [Route("resetpwd")]
        public IActionResult ResetPassword([FromForm] IFormCollection form)
        {
            userService.ResetPassword(int.Parse(form["userId"]));
            return Ok();
        }

        [HttpPost]
        [Route("save")]
        public IActionResult UpdateUserInfo([FromBody] JsonElement data)
        {
            userService.SaveUser(data.ToString());
            return Ok(data);
        }
    }
}
