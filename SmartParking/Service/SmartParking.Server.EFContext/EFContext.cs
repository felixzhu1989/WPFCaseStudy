using SmartParking.Server.EFCore;
using SmartParking.Server.IEFContext;
using System;
using Microsoft.Extensions.Configuration;

namespace SmartParking.Server.EFContext
{
    public class EFContext : IEFContext.IEFContext
    {
        //IOC容器 依赖注入
        private IConfiguration.IConfiguration configuration;
        public EFContext(IConfiguration.IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext();
            //return new EFCoreContext(configuration.Read("DBConnectStr"));
        }
    }
}
