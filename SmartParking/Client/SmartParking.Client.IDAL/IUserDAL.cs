using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.IDAL
{
    public interface IUserDAL
    {
        Task<string> GetAll();
        Task<string> GetRolesByUserId(int userId);

        Task SaveUser(string data);
        Task ResetPassword(string userId);
    }
}
