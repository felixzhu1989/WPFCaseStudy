using Microsoft.Extensions.Options;
using WpfDiDemo.Options;
namespace WpfDiDemo.Services;
internal class UserService:IUserService
{
    private readonly ApplicationOptions _applicationOptions;
    public UserService(IOptions<ApplicationOptions> options)
    {
        _applicationOptions = options.Value;
    }
    public bool Login(string uid, string pwd)
    {
        return uid.Equals("abc") && pwd.Equals("123");
    }
}