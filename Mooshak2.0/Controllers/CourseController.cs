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
        // instance of the userService and courseService
        private CourseService _service = new CourseService();
        private UserService _userService = new UserService();
       
        // gets a list of viewmodels (all courses) and gives the option of creating a new course
        public ActionResult Index()
        {
            List<CourseViewModel> allCourses = _service.GetAllCourses();
            return View(allCourses);
        }

        // opens the Course/Create page
        public ActionResult Create()
        {
            ViewBag.Teachers = GetTeachers();
            return View();
        }

        // receives information from Create() and saves the new course to the database
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            _service.AddToDB(viewModel);
           
            return RedirectToAction("index");

        }

        // opens the Course/Edit page for the chosen course
        public ActionResult Edit(int id)
        {
            var course = _service.GetCourseByID(id);
            ViewBag.Teachers = GetTeachers();

            return View(course);
        }

        private List<SelectListItem> GetTeachers()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.AddRange(_userService.GetSortedUsers("Teacher").Select(x => new SelectListItem() { Value = x.Id, Text = x.FullName }));

            return result;
        }

        // receives information from Edit() and saves the changes to the database
        [HttpPost]
        public ActionResult Edit(CourseViewModel course)
        {
            _service.EditCourseById(course);

            return RedirectToAction("Index");
        }

        // deletes a course that already exists in Mooshak
        public ActionResult Delete(int id)
        {
            _service.DeleteCourseByID(id);

            return RedirectToAction("Index");
            
        }

        // shows information about a course and registered students
        [HttpGet]
        public ActionResult Details(int id)
        {
            CourseViewModel course = _service.GetCourseByID(id);

            return View(course);
        }

        // opens the Course/AddStudentToCourse page
        [HttpGet]
        public ActionResult AddStudentToCourse(int id)
        {
            AddStudentToCourseViewModel model = new AddStudentToCourseViewModel();
            model.CourseID = id;
            var students = _userService.GetSortedUsers("Student");
            model.AvailableStudents = students;
            return View(model);
        }

        // receives information from AddStudentToCourse(id) and saves the changes to the database
        [HttpPost]
        public ActionResult SaveStudentToCourse(int courseId, string studentId)
        {
            _userService.AddStudentToCourse(courseId, studentId);

            return RedirectToAction("Details", new {id = courseId});
        }

        // removes student from course
        public ActionResult RemoveStudentFromCourse(int courseId, string studentId)
        {
            _userService.RemoveStudentFromCourse(courseId, studentId);

            return RedirectToAction("Details", new { id = courseId });
        }

    }
}