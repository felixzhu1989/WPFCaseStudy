using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
namespace ModuleA;
public class ModuleAProfile : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewD,ViewDViewModel>();
        containerRegistry.RegisterDialog<ViewF,ViewFViewModel>();//µ¯´°
    }
}