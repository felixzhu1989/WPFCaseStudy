using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Server.Models;

namespace SmartParking.Server.IService
{
    public interface IRoleService : IServiceBase
    {
        List<RoleInfo> GetRolesByUserId(int userId);
        List<SysUserInfo> GetAllUsers(int roleId);
        void Save(string role, string users, string menus);
    }
}
