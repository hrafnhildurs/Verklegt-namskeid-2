using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;


namespace Mooshak2._0.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        //instance of the userService
        private UserService _service = new UserService();

        // GET: Get all users
        public ActionResult Index()
        {
            List<UserViewModel> allUsers = _service.GetAllUsers();
            return View(allUsers);
        }

        // GET: Edit user user by their ssn
        public ActionResult Edit(string userSSN)
        {
            UserViewModel user;
            try
            {
                ViewBag.RoleList = GetRoles();
                user = _service.GetUserBySSN(userSSN);
            }
            catch(Exception)
            {
                throw new HttpException(404, "User not found!");
            }
            return View(user);
        }

        // POST: Edit user
        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            _service.EditUserBySSN(user);

            return RedirectToAction("Index");
        }

        // Delete user by their ssn
        public ActionResult Delete(string userSSN)
        {
            try
            {
                _service.DeleteUserBySSN(userSSN);
            }
            catch (Exception)
            {
                
                throw new HttpException(404, "User not found!"); ;
            }

            return RedirectToAction("Index");

        }

        // Create multiple users
        public ActionResult CreateMultiple()
        {
            return View();
        }

        //Get details about a user by their ssn
        public ActionResult Details(string userSSN)
        {
            UserViewModel user;
            try
            {
                user = _service.GetUserBySSN(userSSN);
            }
            catch (Exception)
            {
                
                throw new HttpException(404, "User not found!");
            }

            return View(user);
        }

        //Sort users by their role
        public ActionResult SortUsers(string role)
        {
            List<UserViewModel> sortedUsers = _service.GetSortedUsers(role);
            return View("Index", sortedUsers);

        }

        //Get a list of all roles
        private List<SelectListItem> GetRoles()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            result.AddRange(roleManager.Roles.Select(x => new SelectListItem() { Value = x.Name, Text = x.Name }));

            return result;
        }
    }

}