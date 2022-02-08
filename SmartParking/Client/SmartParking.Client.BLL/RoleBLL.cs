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
    public class RoleBLL:IRoleBLL
    {
        private IRoleDAL roleDal;

        public RoleBLL(IRoleDAL roleDal)
        {
            this.roleDal=roleDal;
        }
        public async Task<List<RoleEntity>> GetAll()
        {
            var rolesStr = await roleDal.GetAll();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public async Task<List<RoleEntity>> GetAllByUserId(int userId)
        {
            var rolesStr = await roleDal.GetAllByUserId(userId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public async Task<List<UserEntity>> GetAllUsers(int roleId)
        {
            var usersStr = await roleDal.GetAllUsers(roleId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);
        }

        public Task Save(RoleEntity role, List<int> userIds, List<int> menuIds)
        {
            return roleDal.Save(Newtonsoft.Json.JsonConvert.SerializeObject(role),
                Newtonsoft.Json.JsonConvert.SerializeObject(userIds),
                Newtonsoft.Json.JsonConvert.SerializeObject(menuIds)
            );
        }
    }
}
