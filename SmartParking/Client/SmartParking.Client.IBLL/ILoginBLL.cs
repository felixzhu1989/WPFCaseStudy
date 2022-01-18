using System;
using System.Threading.Tasks;

namespace SmartParking.Client.IBLL
{
    public interface ILoginBLL
    {
        Task<bool> Login(string username, string password);
    }
}
