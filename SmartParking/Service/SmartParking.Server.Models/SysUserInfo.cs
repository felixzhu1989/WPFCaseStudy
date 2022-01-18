using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_user_info")]//表的名称
    public class SysUserInfo
    {
        [Key]//主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自增列
        [Column("user_id")]//列名
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("real_name")]
        public string RealName { get; set; }
        [Column("password")]
        public string PassWord { get; set; }
        [Column("user_icon")]
        public string UserIcon { get; set; }
        [Column("age")]
        public int Age { get; set; }

        //NotMapped特性，不映射到数据库中
        [NotMapped]
        public List<MenuInfo> Menus { get; set; }
    }
}
