using SmartParking.Client.Entity;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using System;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL
{
    public class LoginBLL : ILoginBLL
    {
        //依赖注入
        private ILoginDAL loginDal;
        public LoginBLL(ILoginDAL loginDal)
        {
            this.loginDal = loginDal;
        }
        public async Task<bool> Login(string username, string password)
        {
            var loginStr = await loginDal.Login(username, password);

            //{"id":1,"userName":"admin","passWord":"ABFB5D41B5DCCF7B34A90F32EC475E77"}
            //根据UserEntity修改数据库列名
            //{"userId":1,"userName":"admin","passWord":"ABFB5D41B5DCCF7B34A90F32EC475E77","userIcon":null}
            //用户信息反序列化Json成一个对象
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(loginStr);
            if (userEntity != null)
            {
                //将用户信息保存到全局实体中
                GlobalEntity.CurrentUserInfo = userEntity;
                return true;
            }
            return false;
        }
    }
}
