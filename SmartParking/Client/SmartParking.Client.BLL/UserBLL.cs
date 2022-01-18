using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Client.Entity;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;

namespace SmartParking.Client.BLL
{
    public class UserBLL:IUserBLL
    {
        private IUserDAL userDal;
        public UserBLL(IUserDAL userDal)
        {
            this.userDal = userDal;
        }
        public async Task<List<UserEntity>> GetAll()
        {
           var usersStr=await userDal.GetAll();
           return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);
        }

        public async Task<List<RoleEntity>> GetRolesByUserId(int userId)
        {
            var rolesStr = await userDal.GetRolesByUserId(userId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public Task SaveUser(UserEntity userEntity)
        {
            return userDal.SaveUser(Newtonsoft.Json.JsonConvert.SerializeObject(userEntity));
        }

        public Task ResetPassword(string userId)
        {
            return userDal.ResetPassword(userId);
        }
    }
}
