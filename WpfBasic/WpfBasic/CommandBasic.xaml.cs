using System.Windows.Controls;

namespace WpfBasic;

/// <summary>
/// CommandBasic.xaml 的交互逻辑
/// </summary>
public partial class CommandBasic : Page
{
    public CommandBasic()
    {
        InitializeComponent();
        this.DataContext = new CommandBasicViewModel();
    }
}