using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2._0.Controllers
{
    public class CourseController : Controller
    {
        //instance of the assignmentService
        //private AssignmentsService _service = new AssignmentsService();
        // GET: Assignments
        //public ActionResult Index()
        //{
        //    List<AssignmentViewModel> model = _service.GetAllAssignments();
        //    return View();
        //}


        // Returns a list of courses
        //public ActionResult Index()
        //{
            //athuga þetta
            //List<CourseViewModel> model = _service.GetAllCourses();
            //return View();
        //}

        // Create a new course in mooshak (from RU database)
        public ActionResult Create()
        {
            //TODO
            return null;
        }

        // Change a course that already exists in Mooshak
        public ActionResult Edit()
        {
            //TODO
            return null;
        }

        // Delete a course that already exists in Mooshak
        public ActionResult Delete()
        {
            //TODO
            return null;
        }

        // Shows information course that already exists in Mooshak
        public ActionResult Details()
        {
            //TODO
            return null;
        }
    }
}