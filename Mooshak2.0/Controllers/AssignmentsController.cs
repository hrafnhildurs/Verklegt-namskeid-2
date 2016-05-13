using System;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mooshak2._0.Controllers
{
    public class AssignmentsController : Controller
    {
        // instance of the assignmentService and courseService
        private AssignmentsService _service = new AssignmentsService();
        private CourseService _courseService = new CourseService();

      
        // shows details about a specific assignment by ID and loads the projects associated with the 
        // assignment and gives the option of adding a project to the assignment
        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);

            return View(viewModel);
        }

        // shows a list of all assignments and gives the option of adding a new assignment
        public ActionResult Index()
        {
            var assignments = _service.GetAllAssignments();

            return View(assignments);
        }

        // deletes an assignment by ID
        public ActionResult Delete(int id)
        {
            _service.DeleteAssignmentByID(id);

            return RedirectToAction("Index");
        }

        // opens the Assignments/Create page
        public ActionResult Create()
        {
            var courses = _courseService.GetAllCourses();
            var assignmentViewModel = new AssignmentViewModel
            {
                AvailableCourses = courses,
                Deadline = DateTime.Now

            };

            return View(assignmentViewModel);
        }

        // receives information from Create() and saves the new assignment to the database
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(AssignmentViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("Index");

        }

        // opens the Course/Edit page for the chosen assignment
        public ActionResult Edit(int id)
         {
            var courses = _courseService.GetAllCourses();
            var assignment = _service.GetAssignmentByID(id);
            assignment.AvailableCourses = courses;

            return View(assignment);
         }

        // receives information from Edit() and saves the changes to the database
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(AssignmentViewModel assignment)
        {
            _service.EditAssignmentById(assignment.ID, assignment);
            return RedirectToAction("Index");
        }


    }
}