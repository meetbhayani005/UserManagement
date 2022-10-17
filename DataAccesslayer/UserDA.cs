using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesslayer.Interface;
using DataAccesslayer.Models;
using GlobalEntity;
using Microsoft.EntityFrameworkCore;

namespace DataAccesslayer
{
    public class UserDA : IUserDA
    {
        private UserManagementContext UserContext;
        public UserDA(UserManagementContext Users)
        {
            this.UserContext = Users;
        }

        public async Task<List<GlobalEntity.User>> GetUsers()
        {
            List<Models.Users> testings = await this.UserContext.Users.Where(i=>i.IsDeleted != true).ToListAsync();
            List<GlobalEntity.User> users = new List<GlobalEntity.User>();
            if (testings != null && testings.Count > 0)
            {
                testings.ForEach(item =>
                {
                    users.Add(new GlobalEntity.User()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ProfilePhoto = item.ProfilePhoto,
                        Gender = item.Gender,
                        RoleId = item.RoleId,
                        IsDeleted = item.IsDeleted
                    });
                });
            }
            return users;
        }

        public async Task<List<GlobalEntity.User>> GetUsersByRoleID(int RoleID)
        {
            List<Models.Users> testings = await this.UserContext.Users.Where(i => i.IsDeleted != true && i.RoleId == RoleID).ToListAsync();
            List<GlobalEntity.User> users = new List<GlobalEntity.User>();
            if (testings != null && testings.Count > 0)
            {
                testings.ForEach(item =>
                {
                    users.Add(new GlobalEntity.User()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ProfilePhoto = item.ProfilePhoto,
                        Gender = item.Gender,
                        RoleId = item.RoleId,
                        IsDeleted = item.IsDeleted
                    });
                });
            }
            return users;
        }


        public async Task<GlobalEntity.User> GetUserByID(int ID)
        {

            var data = await this.UserContext.Users.FirstOrDefaultAsync(i => i.Id == ID);
            GlobalEntity.User users = new GlobalEntity.User();
            if (data != null)
            {
                users = (new GlobalEntity.User()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    ProfilePhoto = data.ProfilePhoto,
                    Gender = data.Gender,
                    RoleId = data.RoleId,
                    IsDeleted = data.IsDeleted
                });

            }
            return users;
        }

        public async Task<string> Save(GlobalEntity.User user)
        {
            string response = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(user.ProfilePhoto))
                {
                    string[] newImage = user.ProfilePhoto.Split(',');
                    user.ProfilePhoto = newImage.Length > 1 ? newImage[1] : string.Empty;
                }
                if (user != null && user.Id > 0)
                {
                    var data = await this.UserContext.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    if (data != null)
                    {
                        data.FirstName = user.FirstName;
                        data.LastName = user.LastName;
                        data.Gender = user.Gender;
                        data.RoleId = user.RoleId;
                        data.ProfilePhoto = user.ProfilePhoto;
                        data.IsDeleted = user.IsDeleted != null && user.IsDeleted.Value ? true : false;
                    }
                }
                else
                {
                    DataAccesslayer.Models.Users newuser = new DataAccesslayer.Models.Users();
                    newuser.FirstName = user.FirstName;
                    newuser.LastName = user.LastName;
                    newuser.Gender = user.Gender;
                    newuser.RoleId = user.RoleId;
                    newuser.ProfilePhoto = user.ProfilePhoto;
                    newuser.IsDeleted = user.IsDeleted != null && user.IsDeleted.Value ? true : false;
                    await this.UserContext.Users.AddAsync(newuser);
                }
                this.UserContext.SaveChanges();
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            response = "Success";
            return response;
        }

        public async Task<string> RemoveUser(int ID)
        {
            var data = await this.UserContext.Users.FirstOrDefaultAsync(i => i.Id == ID);
            string Response = string.Empty;
            if (data != null)
            {
                data.IsDeleted = true;
            }
            this.UserContext.SaveChanges();
            Response = "Success";
            return Response;
        }
    }
}
