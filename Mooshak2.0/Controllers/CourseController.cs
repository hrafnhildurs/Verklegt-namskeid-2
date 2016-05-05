using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;

namespace Mooshak2._0.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _service = new CourseService();
       
        
        public ActionResult Index()
        {
            List<CourseViewModel> allCourses = _service.GetAllCourses();
            return View(allCourses);
        }

        // Create a new course in mooshak (from RU database)
        public ActionResult Create()
        {
            //TODO
            return View();
        }

        // Change a course that already exists in Mooshak
        public ActionResult Edit()
        {
            CourseViewModel course = new CourseViewModel();
            course.CourseID = 1;
            course.CourseName = "Forritun";
            course.CourseNumber = "FFF-111";
            course.Semester = "Spring 2016";

            return View(course);
        }

        // Delete a course that already exists in Mooshak
        public ActionResult Delete()
        {
            //TODO
            return null;
        }

        // Shows information about a course that already exists in Mooshak
        [HttpGet]
        public ActionResult Details()
        {
            //CourseViewModel course = _service.GetCourseByID(1);
            CourseViewModel course = new CourseViewModel();
            course.CourseID = 1;
            course.CourseName = "Forritun";
            course.CourseNumber = "FFF-111";
            course.Semester = "Spring 2016";

            return View(course);
        }
    }
}