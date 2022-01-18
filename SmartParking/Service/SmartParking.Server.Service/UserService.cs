using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SmartParking.Server.IConfiguration;
using SmartParking.Server.IService;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service
{
    public class UserService : ServiceBase, IUserService
    {
        private IUtils utils;
        public UserService(IEFContext.IEFContext eFContext, IUtils utils) : base(eFContext)
        {
            this.utils = utils;

        }
             
        public List<RoleInfo> GetRolesByUserId(int userId)
        {
            //Linq映射到SQL
            var roles = (from ur in Context.Set<UserRole>() 
                where ur.UserId == userId 
                select ur.RoleId).ToList();
            return (from role in Context.Set<RoleInfo>()
                where roles.Contains(role.RoleId)
                select role).ToList();
        }

        public void ResetPassword(int userId)
        {
            Context.Set<SysUserInfo>().Where(u => u.UserId == userId).ToList().ForEach(u => u.PassWord = utils.GetMD5Str($"{utils.GetMD5Str("123456")}|{u.UserName}"));
            Context.SaveChanges();
        }

        public void SaveUser(string data)
        {
            //反序列化，拿到用户信息实体对象
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<SysUserInfo>(data);
            //跟新还是删除判断
            //value.state = 1;

            //当新增的时候
            if (value.UserId == 0)
            {
                value.UserIcon = "image/show/temp.jpg";//默认图标
                value.PassWord = utils.GetMD5Str($"{utils.GetMD5Str("123456")}|{value.UserName}");//默认密码
            }

            Context.Entry(value).State = value.UserId == 0 ? EntityState.Added : EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
