using Mooshak2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.CourseList = GetCourses();
       

            return View();
        }

        private List<SelectListItem> GetCourses()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            CourseService courseService = new CourseService();
            result.AddRange(courseService.GetAllCourses().Select(x=>new SelectListItem() { Value = x.CourseID.ToString(), Text = x.CourseName} ));

            return result;
        }

        public ActionResult CreateMultiple()
        {

            return View();
        }
    }

}