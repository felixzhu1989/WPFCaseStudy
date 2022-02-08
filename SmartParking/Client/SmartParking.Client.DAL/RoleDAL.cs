using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Client.IDAL;

namespace SmartParking.Client.DAL
{
    public class RoleDAL:WebDataAccess,IRoleDAL
    {

        public Task<string> GetAll()
        {
            return GetDatas($"{domain}role/all");
        }

        public Task<string> GetAllByUserId(int userId)
        {
            return GetDatas($"{domain}role/all/{userId}");
        }

        public Task<string> GetAllUsers(int roleId)
        {
            return GetDatas($"{domain}role/all_users/{roleId}");
        }

        public Task Save(string role, string users, string menus)
        {
            Dictionary<string,HttpContent> param=new Dictionary<string, HttpContent>
            {
                { "role", new StringContent(role) },
                { "users", new StringContent(users) },
                { "menus", new StringContent(menus) }
            };
            return PostDatas($"{domain}role/save", GetFormData(param));
        }
    }
}
