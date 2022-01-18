using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginViewModel:BindableBase
    {
        private ILoginBLL loginBll;
        public LoginViewModel(ILoginBLL loginBll)
        {
            this.loginBll = loginBll;
        }
        private string userName="admin";
        public string UserName
        {
            get => userName;
            set => SetProperty<string>(ref userName,value);
        }

        private string pwd="123456";
        public string Pwd
        {
            get => pwd;
            set => SetProperty<string>(ref pwd, value);
        }

        private string errorMsg;
        public string ErrorMsg
        {
            get => errorMsg;
            set => SetProperty<string>(ref errorMsg, value);
        }

        //登陆命令
        public  ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }
        private void OnLogin(object obj)
        {
            try
            {
                ErrorMsg = "";
                if (string.IsNullOrEmpty(UserName))
                {
                    throw new Exception("请输入用户名");
                }
                if (string.IsNullOrEmpty(Pwd))
                {
                    throw new Exception("请输入密码");
                }
                //处理登陆逻辑
                if (loginBll.Login(UserName, Pwd).GetAwaiter().GetResult())
                {
                    //关闭登陆窗口，DialogResult=true
                    (obj as Window)!.DialogResult = true;
                }
                else
                {
                    throw new Exception("用户名或密码错误"); 
                }

            }
            catch (Exception ex)
            {
                ErrorMsg = $"登录失败！{ex.Message}";
            }
        }
        #region 关闭和最小化按钮
        //关闭窗口
        public ICommand CloseCommand
        {
            get => new DelegateCommand<object>(OnClose);
        }
        private void OnClose(object obj)
        {
            (obj as Window)!.DialogResult = false;
        }
        //最小化窗口
        public ICommand MinimizeCommand
        {
            get => new DelegateCommand<object>(OnMinimize);
        }
        private void OnMinimize(object obj)
        {
            (obj as Window)!.WindowState = WindowState.Minimized;
        } 
        #endregion
    }
}
