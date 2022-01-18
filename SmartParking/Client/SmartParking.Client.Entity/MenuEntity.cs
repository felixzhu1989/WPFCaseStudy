using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Entity
{
    //对应数据库
    public class MenuEntity
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public int MenuIndex { get; set; }//排序用
        public int MenuType { get; set; }
        public string MenuIcon { get; set; }//图标
        public string MenuHeader { get; set; }//文本
        public string TargetView { get; set; }//视图
    }
}
