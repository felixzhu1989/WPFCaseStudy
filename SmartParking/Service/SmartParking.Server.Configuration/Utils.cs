using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Server.IConfiguration;

namespace SmartParking.Server.Configuration
{
    public class Utils:IUtils
    {
        public string GetMD5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";
            byte[] result = Encoding.Default.GetBytes(inputStr);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
