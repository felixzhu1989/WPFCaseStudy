using System;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
namespace ModuleA.ViewModels;
public class ViewDViewModel:BindableBase,IConfirmNavigationRequest
{
    private string title;
    public string Title
    {
        get => title;
        set { title = value;RaisePropertyChanged(); }
    }
    //每次重新导航的时候是否该重新创建，是否重用原来的实例
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }
    //拦截导航请求
    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
        
    }
    //导航请求确认
    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        bool result = MessageBox.Show("确认导航？", "温馨提示", MessageBoxButton.YesNo) != MessageBoxResult.No;
        continuationCallback(result);
    }
    //负责接收导航参数
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        if(navigationContext.Parameters.ContainsKey("Title"))
            Title = navigationContext.Parameters.GetValue<string>("Title");
    }
}