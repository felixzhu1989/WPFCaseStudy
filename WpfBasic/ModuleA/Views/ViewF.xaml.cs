using System.Windows;
using System.Windows.Controls;
using ModuleA.Event;
using Prism.Events;
namespace ModuleA.Views;
public partial class ViewF : UserControl
{
    private readonly IEventAggregator _aggregator;
    public ViewF(IEventAggregator aggregator)
    {
        _aggregator = aggregator;
        InitializeComponent();
        //接收MessageEvent发布的消息，使用委托
        _aggregator.GetEvent<MessageEvent>().Subscribe(SubMessage);
    }
    private void SubMessage(string str)
    {
        MessageBox.Show($"接收到的消息：{str}");
        //取消订阅消息，这个过程中按钮只弹出一次消息后就取消订阅了，因此只会弹出一次消息
        _aggregator.GetEvent<MessageEvent>().Unsubscribe(SubMessage);
    }
}