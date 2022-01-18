using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using SmartParking.Client.BaseModule.Views;

namespace SmartParking.Client.BaseModule
{
    public class BaseInfoModule:IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //扩展方法，需要引入Prism.Wpf
            containerRegistry.RegisterForNavigation<UserManagementView>();


            containerRegistry.RegisterDialog<ModifyUserDialog>();
        }
    }
}
