using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SmartParking.Server.IService;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        //从IOC容器中获取efContext对象，并传递给父类
        public MenuService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
        }

        public List<MenuInfo> GetMenusByUserId(int userId)
        {
            //获取角色权限
            var roles = (from ur in Context.Set<UserRole>()
                join role in Context.Set<RoleInfo>() 
                    on ur.RoleId equals role.RoleId 
                where ur.UserId == userId && role.State == 1
                select role.RoleId).ToList();
            //菜单去重
            var query = from menu in Context.Set<MenuInfo>()
                join role_menu in Context.Set<RoleMenu>()
                    on menu.MenuId equals role_menu.MenuId
                where roles.Contains(role_menu.RoleId) && menu.State == 1
                select menu;
            return query.Distinct().ToList();
        }

        public List<MenuInfo> GetMenusByRoleId(int roleId)
        {
            //获取角色权限
            var roles = (from role in Context.Set<RoleInfo>()
                         where role.RoleId == roleId && role.State == 1
                         select role.RoleId).ToList();
            //菜单去重
            var query = from menu in Context.Set<MenuInfo>()
                        join role_menu in Context.Set<RoleMenu>()
                            on menu.MenuId equals role_menu.MenuId
                        where roles.Contains(role_menu.RoleId) && menu.State == 1
                        select menu;
            return query.Distinct().ToList();
        }

        public List<MenuInfo> GetAllMenus()
        {
            //Linq SQL映射 ORF框架
            return (from menu in Context.Set<MenuInfo>()
                    where menu.State == 1
                    select menu).ToList();
        }
        //前台的对象通过序列化的方式传递给服务端，然后反序列化
        public void SaveMenu(string data)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<MenuInfo>(data);
            if (value.MenuId == 0)
            {
                var menuIndex = Context.Set<MenuInfo>().Max(i => i.MenuIndex);
                value.MenuIndex = menuIndex + 1;
            }
            value.State = 1;
            //增加还是修改
            Context.Entry(value).State = value.MenuId == 0 ? EntityState.Added : EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
