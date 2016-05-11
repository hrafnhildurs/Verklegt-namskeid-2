using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Models.Entities;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;

namespace Mooshak2._0.Controllers
{
    public class CourseController : Controller
    {
        private CourseService _service = new CourseService();
        private UserService _userService = new UserService();
       
        // creates a list of viewmodels (all courses)
        public ActionResult Index()
        {
            List<CourseViewModel> allCourses = _service.GetAllCourses();
            return View(allCourses);
        }

        // Create a new course in Mooshak
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("index");

        }

        // Change a course that already exists in Mooshak
        public ActionResult Edit(int id)
        {
            var course = _service.GetCourseByID(id);

            return View(course);
        }

        // 
        [HttpPost]
        public ActionResult Edit(CourseViewModel course)
        {
            _service.EditCourseById(course);

            return RedirectToAction("Index");
        }

        // Delete a course that already exists in Mooshak
        public ActionResult Delete(int id)
        {
            _service.DeleteCourseByID(id);

            return RedirectToAction("Index");
            
        }

        // Shows information about a course that already exists in Mooshak
        [HttpGet]
        public ActionResult Details(int id)
        {
            CourseViewModel course = _service.GetCourseByID(id);

            return View(course);
        }

        [HttpGet]
        public ActionResult AddStudentToCourse(int id)
        {
            AddStudentToCourseViewModel model = new AddStudentToCourseViewModel();
            model.CourseID = id;
            var students = _userService.GetAllUsers();
            model.AvailableStudents = students;
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveStudentToCourse(int courseId, string studentId)
        {
            _userService.AddStudentToCourse(courseId, studentId);

            return RedirectToAction("Details", new {id = courseId});
        }

        public ActionResult RemoveStudentFromCourse(int courseId, string studentId)
        {
            _userService.RemoveStudentFromCourse(courseId, studentId);

            return RedirectToAction("Details", new { id = courseId });
        }

        [HttpPost]
        public ActionResult AddStudentToCourse(AddStudentToCourseViewModel model)
        {
            
            return View();
        }
    }
}