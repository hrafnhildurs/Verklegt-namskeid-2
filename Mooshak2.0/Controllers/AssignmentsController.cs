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
        // GET: Assignments
        public ActionResult Index()
        {
            List<AssignmentViewModel> model = _service.GetAllAssignments();
            return View();
        }

        //Get details about a specific assignment
        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var viewModel = _service.DeleteAssignmentByID(id);

            return View(viewModel);
        }

        public ActionResult Create(int id)
        {
            var viewModel = _service.CreateAssignmentByID(id);
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.EditAssignmentByID(id);
            return View(viewModel);
        }
    }
}