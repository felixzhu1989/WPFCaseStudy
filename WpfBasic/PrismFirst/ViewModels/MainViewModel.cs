using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
namespace PrismFirst.ViewModels;
public class MainViewModel:BindableBase
{
    public DelegateCommand<string> OpenCommand { get; }
    public DelegateCommand BackCommand { get; }
    public DelegateCommand ForwardCommand { get; }
    public DelegateCommand<string> OpenDialogCommand { get; }
    private readonly IRegionManager _regionManager;
    private readonly IDialogService _dialogService;
    private IRegionNavigationJournal _journal;
    public MainViewModel(IRegionManager regionManager,IDialogService dialogService)
    {
        OpenCommand = new DelegateCommand<string>(Open);
        BackCommand = new DelegateCommand(Back);
        ForwardCommand = new DelegateCommand(Forward);
        OpenDialogCommand = new DelegateCommand<string>(OpenDialog);
        _regionManager = regionManager;
        _dialogService = dialogService;
    }
    private void Open(string obj)
    {
        //首先通过IRegionManager接口获取当前全部定义的可用区域
        //往这个区域动态的设置内容
        //设置内容的方式是通过依赖注入的形式
        NavigationParameters keys = new NavigationParameters { { "Title", "Hello" } };
        _regionManager.Regions["ContentRegion"].RequestNavigate(obj, callback =>
        {
            if ((bool)callback.Result)
            {
                _journal = callback.Context.NavigationService.Journal;
            }
        },keys);
    }
    private void Back()
    {
        if(_journal.CanGoBack)
            _journal.GoBack();
    }
    private void Forward()
    {
        if(_journal.CanGoForward)
            _journal.GoForward();
    }
    private void OpenDialog(string obj)
    {
        DialogParameters keys = new DialogParameters{{"Title","Test Dialog"}};//传递给弹窗的参数
        _dialogService.ShowDialog(obj,keys, callback =>
        {
          string result=  callback.Parameters.GetValue<string>("Value");
        });
    }
}
