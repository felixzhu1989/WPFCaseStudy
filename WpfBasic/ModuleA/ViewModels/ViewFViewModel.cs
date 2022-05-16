using System;
using ModuleA.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
namespace ModuleA.ViewModels;
public class ViewFViewModel:BindableBase,IDialogAware
{
    private readonly IEventAggregator _aggregator;
    public DelegateCommand CancelCommand { get; set; }
    public DelegateCommand SaveCommand { get; set; }
    public DelegateCommand ReceiveCommand { get; set; }
    public ViewFViewModel(IEventAggregator aggregator)
    {
        _aggregator = aggregator;
        CancelCommand = new DelegateCommand(Cancel);
        SaveCommand = new DelegateCommand(Save);
        ReceiveCommand = new DelegateCommand(Receive);
    }
    private void Receive()
    {
        //向MessageEvent发布Hello Message消息
        _aggregator.GetEvent<MessageEvent>().Publish("Hello Message");
    }
    private void Save()
    {
        OnDialogClosed();
    }
    private void Cancel()
    {
        RequestClose.Invoke(new DialogResult(ButtonResult.No));
    }
    public string Title { get; set; }
    public event Action<IDialogResult>? RequestClose;
    public bool CanCloseDialog()
    {
        return true;
    }
    public void OnDialogClosed()
    {
        //返回给主窗体的参数
        DialogParameters keys = new DialogParameters { { "Value", "Hello" } };
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK,keys));
    }
    //接收弹窗传递过来的参数
    public void OnDialogOpened(IDialogParameters parameters)
    {
        Title = parameters.GetValue<string>("Title");
    }
}