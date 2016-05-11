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

        [HttpGet]
        public ActionResult Index()
        {
            List<AssignmentProjectViewModel> allProjects = _service.GetAllProjects();
            return View(allProjects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AssignmentList = GetAssignmentID();
            return View();
        }

        private List<SelectListItem> GetAssignmentID()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            AssignmentsService assignments = new AssignmentsService();
            result.AddRange(assignments.GetAllAssignments().Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.AssignmentName }));

            return result;
        }


        [HttpPost]
        public ActionResult Create(AssignmentProjectViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("index");

        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var Model = _service.GetProjectByID(id);

            return View(Model);
        }
      

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _service.DeleteProjectByID(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(AssignmentProjectViewModel model)
        {
            return View(model);
        }
    }
}