using SmartParking.Server.IService;
using System;
using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service
{
    public class LoginService :ServiceBase, ILoginService
    {
        
        public LoginService(IEFContext.IEFContext eFContext):base(eFContext)
        {
            
        }
        public void Get(string un, string pwd)
        {
            //Context.Set<SysUserInfo>().Find();

        }
    }
}
