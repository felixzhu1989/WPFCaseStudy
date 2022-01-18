using System;

namespace SmartParking.Server.IService
{
    public interface ILoginService:IServiceBase
    {
        void Get(string un, string pwd);
    }
}
