using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.IDAL
{
    public interface IRoleDAL
    {
        Task<string> GetAll();
        Task<string> GetAllByUserId(int userId);
        Task<string> GetAllUsers(int roleId);

        Task Save(string role, string users, string menus);
    }
}
