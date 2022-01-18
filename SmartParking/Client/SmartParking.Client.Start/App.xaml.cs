using System;
using System.Windows;
using System.Windows.Threading;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using SmartParking.Client.BLL;
using SmartParking.Client.DAL;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using SmartParking.Client.Start.Views;

namespace SmartParking.Client.Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void InitializeShell(Window shell)
        {
            //在初始化窗口之前，先弹出登陆窗口，如果登陆成功则打开主窗口
            if (Container.Resolve<LoginView>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //当从容器中获取Dispatcher的时候，返回的是Application.Current.Dispatcher对象
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);

            //IOC容器 注册
            containerRegistry.Register<ILoginBLL,LoginBLL>();
            containerRegistry.Register<ILoginDAL,LoginDAL>();

            containerRegistry.Register<IUserBLL,UserBLL>();
            containerRegistry.Register<IUserDAL,UserDAL>();


        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //可以改为自动扫描
            moduleCatalog.AddModule<MainModule.MainModule>();
            moduleCatalog.AddModule<BaseModule.BaseInfoModule>();
            
        }
    }
}
