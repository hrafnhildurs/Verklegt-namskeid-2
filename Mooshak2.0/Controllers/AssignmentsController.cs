using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public AssignmentProjectViewModel Create()
        {
            //TODO:
            return null;
        }

        public AssignmentProjectViewModel Edit()
        {
            //TODO:
            return null;
        }
    }
}