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
        public ActionResult Create()
        {
            ViewBag.CourseList = GetCourses();
       

            return View();
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
    }
}