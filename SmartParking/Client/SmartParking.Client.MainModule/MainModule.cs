using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //初始化的时候，添加一个组件到对应的区域
            //比如左侧菜单
            //需要一个RegionManager
           var regionManager= containerProvider.Resolve<IRegionManager>();
           regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", typeof(Views.TreeMenuView));
           regionManager.RegisterViewWithRegion("MainHeaderRegion", typeof(Views.MainHeaderView));
        }
       
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册对象
            containerRegistry.Register<Views.TreeMenuView>();
            containerRegistry.Register<Views.MainHeaderView>();
        }
    }
}
