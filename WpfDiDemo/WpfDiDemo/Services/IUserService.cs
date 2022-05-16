namespace WpfDiDemo.Services;

internal interface IUserService
{
    bool Login(string uid, string pwd);
}