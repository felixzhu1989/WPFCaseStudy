using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Client.IDAL;

namespace SmartParking.Client.DAL
{
    public class WebDataAccess:IWebDataAccess
    {
        protected string domain = "http://localhost:5000/api/";
        //protected string domain = "http://10.9.18.31:5000/api/";

        public async Task<string> GetDatas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.GetAsync(url).GetAwaiter().GetResult();
                return await resp.Content.ReadAsStringAsync();
            }
        }

        //表单
        public MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = $"--{DateTime.Now.Ticks:x}--";
            postContent.Headers.Add("ContentType", $"multipart/from-data,boundary={boundary}");
            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }
            return postContent;
        }

        public async Task<string> PostDatas(string url, Dictionary<string, HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, GetFormData(contents)).GetAwaiter().GetResult();
                return await resp.Content.ReadAsStringAsync();
            }
        }
        public async Task<string> PostDatas(string url, HttpContent contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync(url, contents).GetAwaiter().GetResult();
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetFileList()
        {
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync($"{domain}file/check");
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Login(string un, string pwd)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = $"--{DateTime.Now.Ticks:x}--";
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
            postContent.Add(new StringContent(un), "username");
            postContent.Add(new StringContent(pwd), "pwd");

            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync($"{domain}login/login", postContent);
                var data = await resp.Content.ReadAsStringAsync();
                return data;
            }
        }
    }
}
