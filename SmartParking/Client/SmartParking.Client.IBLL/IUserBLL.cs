using SmartParking.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.IBLL
{
    public interface IUserBLL
    {
        Task<List<UserEntity>> GetAll();
        Task<List<RoleEntity>> GetRolesByUserId(int userId);

        Task SaveUser(UserEntity userEntity);
        
        Task ResetPassword(string userId);

        Task ChangeState(int userId, int state);
        Task UpdateRoles(int userId, List<int> roles);
    }
}
