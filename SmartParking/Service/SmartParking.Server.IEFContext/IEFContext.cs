using SmartParking.Server.EFCore;
using System;

namespace SmartParking.Server.IEFContext
{
    public interface IEFContext
    {
        EFCoreContext CreateDBContext();
    }
}
