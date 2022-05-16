using System.Windows.Controls;

namespace WpfBasic;

/// <summary>
/// BindingBasic.xaml 的交互逻辑
/// </summary>
public partial class BindingBasic : Page
{
    public BindingBasic()
    {
        InitializeComponent();
        this.DataContext = new Person { Name = "张三" };
    }
}
public class Person
{
    public string Name { get; set; }
}