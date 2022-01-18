using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Models
{
    [Table("menus")]
    public class MenuInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [Column("menu_icon", TypeName = "nvarchar(4)")]
        public string MenuIcon { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("menu_index")]
        public int MenuIndex { get; set; }

        [Column("menu_type")]
        public int MenuType { get; set; }
        
        [Column("menu_header")]
        public string MenuHeader { get; set; }//文本

        [Column("target_view")]
        public string TargetView { get; set; }//视图

        [Column("state")]
        [DefaultValue(1)]
        public int State { get; set; }
    }
    //图标，Iconfont字体图标,保存的是编号，在EFCoreContext中配置转换
    //注意每个属性都应该是public 否则EFCore不会在数据库中创建列
}
