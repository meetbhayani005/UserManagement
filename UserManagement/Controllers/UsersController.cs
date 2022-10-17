using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Businesslayer.Interface;
using Microsoft.AspNetCore.Mvc;
using GlobalEntity;
using DataAccesslayer.Models;

namespace UserManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBc UsersBC;
        public UsersController(IUserBc Users)
        {
            this.UsersBC = Users;
        }
        public async Task<IActionResult> Index()
        {
            List<GlobalEntity.User> Users = await this.UsersBC.GetUsers();
            return View(Users);
        }

        public IActionResult Create()
        {
            return View(new GlobalEntity.User());
        }

        public async Task<IActionResult> Edit(int ID)
        {
            GlobalEntity.User User = await this.UsersBC.GetUserByID(ID);
            return View("Create",User);
        }

        public async Task<ActionResult> Remove(int ID)
        {
            string response = await this.UsersBC.RemoveUser(ID);
            return Redirect("/Users/Index");
        }

        public async Task<ActionResult> Save(GlobalEntity.User user)
        {
            string response = await this.UsersBC.Save(user);
            return Redirect("/Users/Index");
        }
        public async Task<IActionResult> Filter(int RoleID)
        {
            List<GlobalEntity.User> Users = await this.UsersBC.GetUsersByRoleID(RoleID);
            return View("Index",Users);
        }
    }
}
