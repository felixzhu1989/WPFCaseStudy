using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Client.IDAL;

namespace SmartParking.Client.DAL
{
    public class UserDAL:WebDataAccess,IUserDAL
    {

        public Task<string> GetAll()
        {
            //服务接口
            return GetDatas($"{domain}user/all");
        }

        public Task<string> GetRolesByUserId(int userId)
        {
            //服务端对应有一个接口
            return GetDatas($"{domain}user/roles/{userId}");
        }

        public Task ResetPassword(string userId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId",new StringContent(userId));
            return PostDatas($"{domain}user/resetpwd", param);
        }

        public Task SaveUser(string data)
        {
            StringContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return PostDatas($"{domain}user/save", content);
        }
    }
}
