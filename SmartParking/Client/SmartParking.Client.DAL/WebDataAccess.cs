using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL
{
    public class WebDataAccess
    {
        protected string domain = "http://localhost:5000/api/";
        //protected string domain = "http://10.9.18.31:5000/api/";

        public Task<string> GetDatas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.GetAsync(url).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }

        //表单
        private MultipartFormDataContent GetFromData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = $"------{DateTime.Now.Ticks.ToString("x")}------";
            postContent.Headers.Add("ContentType", $"muiltipart/from-data,boundary={boundary}");
            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }
            return postContent;
        }

        public Task<string> PostDatas(string url, Dictionary<string, HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, GetFromData(contents)).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }
        public Task<string> PostDatas(string url, HttpContent contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, contents).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }
    }
}
