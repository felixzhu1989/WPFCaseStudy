using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.BaseModule.Models;
using SmartParking.Client.Common;
using SmartParking.Client.IBLL;
using Unity;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        public ObservableCollection<UserModel> UserList { get; set; } = new();
        //依赖注入
        private IUnityContainer unityContainer;
        private IDialogService dialogService;
        private IUserBLL userBll;
        private IRoleBLL roleBll;
        public UserManagementViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea, IDialogService dialogService, IUserBLL userBll, IRoleBLL roleBll) : base(regionManager, unityContainer)
        {
            this.PageTitle = "系统用户管理";

            this.userBll = userBll;
            this.roleBll = roleBll;
            this.unityContainer = unityContainer;
            this.dialogService = dialogService;
            //IsCanClose = false;//让窗口不能关闭

            //进入页面就刷新并显示数据
            Refresh();
        }

        public override void Refresh()
        {
            //ShowLoading();
            //用户信息刷新
            UserList.Clear();
            Task.Run(async () =>
            {
                //var users = userBll.GetAll().GetAwaiter().GetResult();
                var users = await userBll.GetAll();
                foreach (var item in users)
                {
                    UserModel userModel = new UserModel()
                    {
                        Index = users.IndexOf(item) + 1,//序号
                        UserId = item.UserId,
                        UserName = item.UserName,
                        UserIcon = "pack://application:,,,/SmartParking.Client.Assets;component/Images/erha.png",
                        //UserIcon = System.Configuration.ConfigurationManager.AppSettings["api_domain"]!.ToString()+item.UserIcon,
                        Age = item.Age,
                        Password = item.Password,
                        RealName = item.RealName
                    };
                    //用户角色
                    //var roles = userBll.GetRolesByUserId(userModel.UserId).GetAwaiter().GetResult();
                    var roles = await roleBll.GetAllByUserId(item.UserId);
                    //填充
                    roles?.ForEach(r => userModel.Roles.Add(new RoleModel()
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                        State = r.State
                    }));

                    //编辑命令
                    userModel.EditCommand = new DelegateCommand<object>(EditItem);
                    //删除
                    userModel.DeleteCommand = new DelegateCommand<object>(DeleteItem);
                    //角色分配
                    userModel.RoleCommand = new DelegateCommand<object>(SetRoles);
                    //角色分配
                    userModel.PwdCommand = new DelegateCommand<object>(SetPassword);

                    //跨线程问题,将UserList.Add(userModel);操作放入主线程中运行
                    unityContainer.Resolve<Dispatcher>().Invoke(() =>
                    {
                        UserList.Add(userModel);
                    });
                }
                //HideLoading();
            });
        }

        public override void AddItem()
        {
            //添加用户信息
            DialogParameters param = new DialogParameters { { "type", 0 } // 新增
            };

            ShowEditDialog(param);

        }

        private void EditItem(object obj)
        {
            DialogParameters param = new DialogParameters
            {
                { "type", 1 }, //编辑
                { "model", obj as UserModel }
            };
            ShowEditDialog(param);

            //弹窗，首先设计窗口
            //dialogService.ShowDialog("ModifyUserDialog", param, result =>
            //{
            //    if (result.Result == ButtonResult.OK)
            //    {
            //        System.Windows.MessageBox.Show("数据保存成功", "提示");
            //        Refresh();
            //    }
            //});

        }
        private void ShowEditDialog(DialogParameters param)
        {
            dialogService.ShowDialog(
                "ModifyUserDialog",
                param,
                new Action<IDialogResult>(result =>
                {
                    if (result != null && result.Result == ButtonResult.OK)
                    {
                        System.Windows.MessageBox.Show("数据已保存", "提示");
                        this.Refresh();
                    }
                }));
        }


        private async void DeleteItem(object obj)
        {
            if (System.Windows.MessageBox.Show("是否确定删除此用户信息？", "提示", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                var model = obj as UserModel;
                //把用户的状态设置成不可用（逻辑删除），也可以物理删除
                if (model != null) await userBll.ChangeState(model.UserId, 0);
                Refresh();
            }
        }
        private void SetRoles(object obj)
        {
            DialogParameters param = new DialogParameters
            {
                { "userId", (obj as UserModel).UserId }, // Dialog进行数据保存，知道对哪个用户进行操作
                { "roles", (obj as UserModel).Roles.Select(r => r.RoleId).ToList() }
            };

            dialogService.ShowDialog(
                "ModifyRolesDialog",
                param,
                new Action<IDialogResult>(result =>
                {
                    if (result != null && result.Result == ButtonResult.OK)
                    {
                        System.Windows.MessageBox.Show("角色分配完成", "提示");
                        this.Refresh();
                    }
                }));
        }

        private void SetPassword(object obj)
        {
           // ShowLoading("正在重置...");
            Task.Run(async () =>
            {
                await userBll.ResetPassword((obj as UserModel).UserId.ToString());
                System.Windows.MessageBox.Show("密码已重置", "提示");
               // HideLoading();
            });
        }
    }
}
