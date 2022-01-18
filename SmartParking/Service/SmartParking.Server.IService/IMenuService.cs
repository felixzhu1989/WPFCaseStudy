using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IService
{
    public interface IMenuService : IServiceBase
    {
        List<MenuInfo> GetMenusByUserId(int userId);
        //角色编辑的时候用到
        List<MenuInfo> GetMenusByRoleId(int roleId);
        List<MenuInfo> GetAllMenus();
        //包含新增和修改
        void SaveMenu(string data);
    }
}
