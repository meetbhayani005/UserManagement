using DataAccesslayer.Interface;
using System;
using GlobalEntity;
using System.Collections.Generic;
using Businesslayer.Interface;
using System.Threading.Tasks;

namespace Businesslayer
{
    public class UserBusinessLogic : IUserBc
    {
        private readonly IUserDA userDA;
        public UserBusinessLogic(IUserDA users)
        {
            this.userDA = users;
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.userDA.GetUsers();
        }
        public async Task<GlobalEntity.User> GetUserByID(int ID)
        {
            return await this.userDA.GetUserByID(ID);
        }

        public async Task<string> Save(GlobalEntity.User user)
        {
            return await this.userDA.Save(user);
        }
        public async Task<string> RemoveUser(int ID)
        {
            return await this.userDA.RemoveUser(ID);
        }
        public async Task<List<User>> GetUsersByRoleID(int RoleID)
        {
            return await this.userDA.GetUsersByRoleID(RoleID);
        }
    }
}
