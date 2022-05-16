using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using ModuleA;
using ModuleB;
using Prism.Modularity;
using PrismFirst.Views;
namespace PrismFirst;

public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainView>();
    }
    //依赖注入
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>();
        containerRegistry.RegisterForNavigation<ViewB>();
        containerRegistry.RegisterForNavigation<ViewC>();
    }
    //一、通过代码的方式添加模块
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleAProfile>();
        moduleCatalog.AddModule<ModuleBProfile>();
        base.ConfigureModuleCatalog(moduleCatalog);
    }
    //二、通过配置文件夹
    //protected override IModuleCatalog CreateModuleCatalog()
    //{
    //    return new DirectoryModuleCatalog { ModulePath = @".\Modules" };
    //}
}