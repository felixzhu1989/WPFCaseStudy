using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace SmartParking.Client.MainModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }//图标
        public string MenuHeader { get; set; }//文本
        public string TargetView { get; set; }//对应的视图，通过regionManager打开
        private bool isExpanded=true;//是否展开
        public bool IsExpanded
        {
            get => isExpanded;
            set => SetProperty(ref isExpanded, value);
        }
        public List<MenuItemModel> Children { get; set; }//子菜单
        //将当前对象传递进方法中
        public ICommand OpenViewCommand =>
            new DelegateCommand(() =>
            {
                if ((Children == null || Children.Count == 0) && !string.IsNullOrEmpty(TargetView))
                {
                    //页面跳转
                    regionManager.RequestNavigate("MainContentRegion", TargetView);
                }
                else
                {
                    IsExpanded = !IsExpanded;//展开或折叠
                }
            });


        private IRegionManager regionManager;
        public MenuItemModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}
