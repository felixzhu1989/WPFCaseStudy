using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IConfiguration
{
    public interface IUtils
    {
       public string GetMD5Str(string inputStr);
    }
}
