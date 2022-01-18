using SmartParking.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL
{
    public class LoginDAL: WebDataAccess,ILoginDAL
    {
        public Task<string> Login(string username, string password)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("username",new StringContent(username));
            contents.Add("password", new StringContent(password));
            return PostDatas($"{domain}user/login", contents);
        }
    }
}
