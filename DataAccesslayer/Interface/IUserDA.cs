using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Interface
{
    public interface IUserDA
    {
        Task<List<GlobalEntity.User>> GetUsers();

        Task<GlobalEntity.User> GetUserByID(int ID);
        Task<string> Save(GlobalEntity.User user);
        Task<string> RemoveUser(int ID);
        Task<List<GlobalEntity.User>> GetUsersByRoleID(int RoleID);
    }
}
