using System;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mooshak2._0.Controllers
{
    public class AssignmentProjectController : Controller
    {
        //instance of the AssignmentProjectService
        private AssignmentProjectService _service = new AssignmentProjectService();
        private AssignmentsService _assignmentsService = new AssignmentsService();

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Index()
        {
            List<AssignmentProjectViewModel> allProjects = _service.GetAllProjects();
            return View(allProjects);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Student")]
        public ActionResult UnfinishedProjects()
        {
            List<AssignmentProjectViewModel> projects = _service.GetAllUnfinishedProjects();
            return View(projects);
        }
        /*[HttpGet]
        public ActionResult Create()
        {
            ViewBag.AssignmentList = GetAssignmentID();
            return View();
        }*/

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Create(int id)
        {
            var assignment = _assignmentsService.GetAssignmentByID(id);
            var viewModel = new AssignmentProjectViewModel()
            {
                AssignmentID = assignment.ID,
                AssignmentName = assignment.AssignmentName,
                Deadline = assignment.Deadline
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Save(AssignmentProjectViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("Details", "Assignments", new { id = viewModel.AssignmentID });
        }

        [Authorize(Roles = "Administrator, Teacher")]
        private List<SelectListItem> GetAssignmentID()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            AssignmentsService assignments = new AssignmentsService();
            result.AddRange(assignments.GetAllAssignments().Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.AssignmentName }));

            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Edit(int id)
        {
            var Model = _service.GetProjectByID(id);

            return View(Model);
        }

        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Delete(int id, int assignmentId)
        {
            _service.DeleteProjectById(id);

            return RedirectToAction("Details", "Assignments", new { id = assignmentId });

        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Details(AssignmentProjectViewModel model)
        {
            return View(model);
        }
    }
}