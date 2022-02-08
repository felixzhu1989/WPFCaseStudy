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
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent> { { "userId", new StringContent(userId) } };
            return PostDatas($"{domain}user/resetpwd", GetFormData(param));
        }

        public Task SaveUser(string data)
        {
            StringContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return PostDatas($"{domain}user/save", content);
        }

        public Task ChangeState(int userId, int state)
        {
            //  什么时候用Post  什么时候用Get     WebApi的开发人员去思考
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId.ToString()));
            param.Add("state", new StringContent(state.ToString()));

            return this.PostDatas($"{domain}user/state", GetFormData(param));
        }
        public Task UpdateRoles(int userId, string roles)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId.ToString()));
            param.Add("roles", new StringContent(roles));

            return this.PostDatas($"{domain}user/roles", this.GetFormData(param));
        }

    }
}
