using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.BaseModule.Models;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.BaseModule.ViewModels
{
    //弹窗的逻辑
    public class ModifyUserDialogViewModel : BindableBase, IDialogAware
    {
        private IUserBLL userBll;
        public ModifyUserDialogViewModel(IUserBLL userBll)
        {
            this.userBll= userBll;

        }

        public string Title => "用户信息编辑";
        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog() => true;
        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //根据传入的参数，动态判断，新增还是编辑，
            //接收编辑状态，获取要编辑的用户信息
            MainModel = parameters.GetValue<UserModel>("model");

        }

        private UserModel mainModel = new UserModel();
        public UserModel MainModel
        {
            get => mainModel;
            set => SetProperty<UserModel>(ref mainModel, value);
        }

        //确认
        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                //确认操作
                //数据校验（关键字不能为空，年龄做数字区间校验，做UserName的唯一检查（自定义特性检查））、

                //校验通过
                //保存数据到数据库，新增和修改
                userBll.SaveUser(new Entity.UserEntity()
                {
                    UserId = MainModel.UserId,
                    UserName = MainModel.UserName,
                    RealName = MainModel.RealName,
                    //UserIcon = MainModel.UserIcon?.Replace(System.Configuration.ConfigurationManager.AppSettings["api_domain"].ToString(), ""),
                    Password = MainModel.Password,
                    Age = MainModel.Age
                });
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });
        }


        //取消
        public ICommand CancelCommand => new DelegateCommand(() => { RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel)); });
    }
}
