using GlobalEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer.Interface
{
    public interface IUserBc
    {
        public Task<List<User>> GetUsers();
        public Task<GlobalEntity.User> GetUserByID(int ID);
        public Task<string> Save(GlobalEntity.User user);
        public Task<string> RemoveUser(int ID);
        public Task<List<GlobalEntity.User>> GetUsersByRoleID(int RoleID);
    }
}
