using System;
using System.Threading.Tasks;

namespace SmartParking.Client.IDAL
{
    public interface ILoginDAL
    {
        Task<string> Login(string username, string password);
    }
}
