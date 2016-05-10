﻿using Mooshak2._0.Models.ViewModels;
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

        

        //Get details about a specific assignment
        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);

            return View(viewModel);
        }


        /*public ActionResult Delete(int id)
        {
            //var viewModel = _service.DeleteAssignmentByID(id);

            //return View(viewModel);
        }*/

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AssignmentViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("index");

        }

        /* public ActionResult Edit(int id)
         {
             //var viewModel = _service.EditAssignmentByID(id);
             //return View(viewModel);
         }*/
    }
}