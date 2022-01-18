using System;

namespace SmartParking.Server.IConfiguration
{
    public interface IConfiguration
    {
        string Read(string key);
    }
}
