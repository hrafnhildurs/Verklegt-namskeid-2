using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;


namespace Mooshak2._0.Controllers
{
    public class UserController : Controller
    {
        private UserService _service = new UserService();
        // GET: User
        public ActionResult Index()
        {
            List<UserViewModel> allUsers = _service.GetAllUsers();
            return View(allUsers);
        }

        public ActionResult Edit(string userSSN)
        {
            ViewBag.RoleList = GetRoles();
            var user = _service.GetUserBySSN(userSSN);
                return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            _service.EditUserBySSN(user);


            return RedirectToAction("Index");
        }

        public ActionResult Delete(string userSSN)
        {
            _service.DeleteUserBySSN(userSSN);

            return RedirectToAction("Index");

        }


        public ActionResult CreateMultiple()
        {
            return View();
        }


        public ActionResult Details(string userSSN)
        {
           UserViewModel user = _service.GetUserBySSN(userSSN);
            return View(user);
        }

        public ActionResult SortUsers(string role)
        {
            List<UserViewModel> sortedUsers = _service.GetSortedUsers(role);
            return View("Index", sortedUsers);

        }

        private List<SelectListItem> GetRoles()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            result.AddRange(roleManager.Roles.Select(x => new SelectListItem() { Value = x.Name, Text = x.Name }));

            return result;
        }
    }

}