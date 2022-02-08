using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SmartParking.Client.Common.MessageSentEvent;
using Unity;

namespace SmartParking.Client.Common
{
    //不需要实例化，用于继承，使用abstract
    public abstract class ViewModelBase :INavigationAware
    {
        //这里使用的是普通，如果页面中修改了某个数据，在标签上提示一个*代表未保存（这里未实现）
        public string PageTitle { get; set; } = "标签标题";
        public bool IsCanClose { get; set; } = true;
        public string NavUri { get; set; }

        //依赖注入
        private IUnityContainer unityContainer;
        private IRegionManager regionManager;
        public ViewModelBase(IRegionManager regionManager,IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.regionManager = regionManager;
        }

        public DelegateCommand CloseCommand => new DelegateCommand(() =>
        {
            //关闭操作
            //根据Uri获取对应的已注册的对象名称
            var obj = unityContainer.Registrations.FirstOrDefault(v => v.Name == NavUri);
            string name = obj.MappedToType.Name;
            //再从Region的Views里面找到对象
            if (!string.IsNullOrEmpty(name))
            {
                var region = regionManager.Regions["MainContentRegion"];
                var view = region.Views.FirstOrDefault(v => v.GetType().Name == name);
                //把对象从region的views里移除
                if (view != null) region.Remove(view);
            }
        });
        public DelegateCommand RefreshCommand => new DelegateCommand(Refresh);
        public DelegateCommand AddCommand => new DelegateCommand(AddItem);

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;//满足什么条件跳转页面
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }



        public virtual void Refresh() { }
        public virtual void AddItem() { }
        public virtual void Export() { }





        //public bool IsShowRefresh { get; set; } = true;
        //public bool IsShowAdd { get; set; } = true;
        //public bool IsShowExport { get; set; } = false;

        //public DelegateCommand<string> CloseCommand { get; private set; }
        //public DelegateCommand RefreshCommand { get; set; }
        //public DelegateCommand AddCommand { get; set; }
        //public DelegateCommand ExportCommand { get; set; }

        //private string searchText;
        //public string SearchText
        //{
        //    get => searchText;
        //    set { SetProperty<string>(ref searchText, value); }
        //}

        //public Func<bool> CanNavigationTargetFunc { get; set; }
        //public bool IsNavigationTarget(NavigationContext navigationContext)
        //{
        //    return CanNavigationTargetFunc == null ? true : CanNavigationTargetFunc();
        //}
        //public void OnNavigatedFrom(NavigationContext navigationContext)
        //{

        //}

        //public Action<NavigationContext> NavigatedToAction;
        //public void OnNavigatedTo(NavigationContext navigationContext)
        //{
        //    NavUri = navigationContext.Uri.ToString();
        //    // 传递过来的车道
        //    NavigatedToAction?.Invoke(navigationContext);
        //}
        //protected void ShowLoading(string tip = "正在加载....")
        //{
        //    this.ea?.GetEvent<LoadingEvent>().Publish(new LoadingPayload { IsShow = true, Message = tip });
        //}
        //protected void HideLoading()
        //{
        //    this.ea?.GetEvent<LoadingEvent>().Publish(new LoadingPayload { IsShow = false });
        //}

        //IEventAggregator ea;
        //public ViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        //{
        //    this.ea = ea;

        //    CloseCommand = new DelegateCommand<string>((param) =>
        //    {
        //        var obj = unityContainer.Registrations.Where(v => v.Name == NavUri).FirstOrDefault();
        //        string name = obj.MappedToType.Name;
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            var region = regionManager.Regions["MainContentRegion"];
        //            var view = region.Views.Where(v => v.GetType().Name == name).FirstOrDefault();
        //            if (view != null)
        //                region.Remove(view);
        //        }
        //    });

        //    RefreshCommand = new DelegateCommand(Refresh);
        //    AddCommand = new DelegateCommand(AddItem);
        //    ExportCommand = new DelegateCommand(Export);

        //    this.Refresh();
        //}



        
    }
}
