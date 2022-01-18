using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Mvvm;
using SmartParking.Client.Entity;

namespace SmartParking.Client.MainModule.ViewModels
{
    public class MainHeaderViewModel:BindableBase
    {
        public string? CurrentUserName { get; set; }//null able string type

        public MainHeaderViewModel(IContainerProvider containerProvider)
        {
            if (GlobalEntity.CurrentUserInfo != null)
            {
                CurrentUserName = GlobalEntity.CurrentUserInfo.UserName;//RealName?
            }
        }
    }
}
