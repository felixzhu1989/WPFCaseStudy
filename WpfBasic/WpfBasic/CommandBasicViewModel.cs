using System.Windows;
namespace WpfBasic;
public class CommandBasicViewModel:ViewModelBase
{
    public MyCommand ShowCommand { get; set; }
    private string name = null!;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }
    private string title = null!;
    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged();
        }
    }
    public CommandBasicViewModel()
    {
        Name = "Hello";
        ShowCommand = new MyCommand(Show);
    }
    public void Show()
    {
        Name = "点击了按钮";
        Title = "我是标题";
        MessageBox.Show("点击了按钮");
    }
}