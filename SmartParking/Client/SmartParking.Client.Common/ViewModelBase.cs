using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Unity;

namespace SmartParking.Client.Common
{
    //不需要实例化，用于继承，使用abstract
    public abstract class ViewModelBase : INavigationAware
    {
        //这里使用的是普通，如果页面中修改了某个数据，在标签上提示一个*代表未保存（这里未实现）
        public string PageTitle { get; set; } = "标签标题";
        public bool IsCanClose { get; set; } = true;
        private string NavUri { get; set; }
        //依赖注入
        private IUnityContainer unityContainer;
        private IRegionManager regionManager;
        public ViewModelBase(IUnityContainer unityContainer, IRegionManager regionManager)
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

        public DelegateCommand RefreshCommand => new DelegateCommand(Refresh);
        public DelegateCommand AddCommand => new DelegateCommand(AddItem);
        public virtual void Refresh() { }
        public virtual void AddItem() { }

    }
}
