using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Entity
{
    /// <summary>
    /// 全局实体
    /// </summary>
    public class GlobalEntity
    {
        public static UserEntity CurrentUserInfo { get; set; }
    }
}
