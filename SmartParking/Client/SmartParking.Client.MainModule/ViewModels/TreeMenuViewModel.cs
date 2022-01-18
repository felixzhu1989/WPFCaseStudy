using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using SmartParking.Client.Entity;
using SmartParking.Client.MainModule.Models;

namespace SmartParking.Client.MainModule.ViewModels
{
    public class TreeMenuViewModel
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();
        //原始数据列表，没有树形结构，通过递归的方式初始化
        private List<MenuEntity> originMenu;
        private IRegionManager regionManager;
        public TreeMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //获取菜单数据
            originMenu = GlobalEntity.CurrentUserInfo?.Menus!;
            FillMenus(Menus,0);
        }


        //菜单树型结构递归方法
        private void FillMenus(List<MenuItemModel> menus, int parentId)
        {
            var sub = originMenu.Where(m => m.ParentId == parentId).OrderBy(o => o.MenuIndex);
            if (sub.Count() > 0)
            {
                foreach (var item in sub)
                {
                    MenuItemModel mm = new MenuItemModel(regionManager)
                    {
                        MenuHeader = item.MenuHeader,
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView
                    };
                    menus.Add(mm);
                    FillMenus(mm.Children=new List<MenuItemModel>(),item.MenuId);
                }
            }

        }


    }
}
