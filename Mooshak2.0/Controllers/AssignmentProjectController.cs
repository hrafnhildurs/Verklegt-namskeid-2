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
        public ActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AssignmentProjectViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(AssignmentProjectViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(AssignmentProjectViewModel model)
        {
            return View(model);
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