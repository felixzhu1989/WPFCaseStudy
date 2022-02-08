using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Server.Models;

namespace SmartParking.Server.IService
{
    public interface IUserService:IServiceBase
    {
        List<RoleInfo> GetRolesByUserId(int userId);
        void ResetPassword(int userId);
        void SaveUser(string data);
        void ChangeState(int userId, int state);
        void UpdateRoles(int userId, List<int> roles);
    }
}
