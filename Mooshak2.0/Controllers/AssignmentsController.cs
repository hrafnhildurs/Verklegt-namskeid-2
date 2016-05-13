using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mooshak2._0.Controllers
{
    public class AssignmentsController : Controller
    {
        //instance of the assignmentService
        private AssignmentsService _service = new AssignmentsService();
        private CourseService _courseService = new CourseService();
        // GET: Assignments


        //Get details about a specific assignment
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);

            return View(viewModel);
        }

        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var assignments = _service.GetAllAssignments();

            return View(assignments);
        }

        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            _service.DeleteAssignmentByID(id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var courses = _courseService.GetAllCourses();
            var assignmentViewModel = new AssignmentViewModel {AvailableCourses = courses};

            return View(assignmentViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(AssignmentViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
         {
            var courses = _courseService.GetAllCourses();
            var assignment = _service.GetAssignmentByID(id);
            assignment.AvailableCourses = courses;

            return View(assignment);
         }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(AssignmentViewModel assignment)
        {
            _service.EditAssignmentById(assignment.ID, assignment);
            //update assignment
            return RedirectToAction("Index");
        }


    }
}