using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Models;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartParking.Server.EFCore
{
    /* Microsoft.EntityFrameworkCore.SqlServer
     * Microsoft.EntityFrameworkCore.Tools
     * 如何生成数据库
     * 设为启动项目
     * 工具-NuGet包管理器-程序包管理器控制台
     * 默认项目设置成EFCore
     * 输入命名：add-migration A1
     * 产生如下结果
     * Build started...
        Build succeeded.
        To undo this action, use Remove-Migration.
        生成了Migrations文件夹，其中有此次生成数据表的快照
     * 然后再输入命名：update-database
     * 产生如下结果
     *  Build started...
        Build succeeded.
        Security Warning: The negotiated TLS 1.0 is an insecure protocol and is supported for backward compatibility only. The recommended protocol version is TLS 1.2 and later.
        Applying migration '20220110074455_A1'.
        Done.
     *  到SQLServer中发现，表格sys_user_info被创建了
     *  并且多了一个提交记录表__EFMigrationsHistory
     *
     */
    public class EFCoreContext:DbContext
    {
        private string strConn = @"Server=PDMSERVER\SQLEXPRESSHALTON;Database=SmartParkingDB;Uid=sa;Pwd=Epdm2018";
        //服务器本机登陆
        //private string strConn = @"Server=PDMSERVER\SQLEXPRESSHALTON;Database=SmartParkingDB;Trusted_Connection=True";
        public EFCoreContext()
        {
            
        }

        //应该写入到配置文件appsettings.json中
        //private string strConn;
        //public EFCoreContext(string strConn)
        //{
        //    this.strConn = strConn;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //菜单表中的字体图标值转换，储存和获取数据时都会通过这个转换器进行
            ValueConverter iconValueConverter = new ValueConverter<string, string>(v=>string.IsNullOrEmpty(v)?null:((int)v.ToCharArray()[0]).ToString("x"),v=>v==null?"":((char)int.Parse(v,System.Globalization.NumberStyles.HexNumber)).ToString());
            modelBuilder.Entity<MenuInfo>().Property(p => p.MenuIcon).HasConversion(iconValueConverter);

            //联合主键
            modelBuilder.Entity<RoleMenu>().HasKey(pk => new { pk.MenuId, pk.RoleId });
            modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserId, pk.RoleId });

        }

        public DbSet<SysUserInfo> SysUserInfo { get;set; }
        public DbSet<MenuInfo> MenuInfo { get;set; }
        public DbSet<RoleInfo> RoleInfo { get;set; }
        public DbSet<RoleMenu> RoleMenu { get;set; }
        public DbSet<UserRole> UserRole { get;set; }



    }
}
