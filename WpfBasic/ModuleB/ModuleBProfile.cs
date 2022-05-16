using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
namespace ModuleB;
public class ModuleBProfile:IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewE>();
    }
}