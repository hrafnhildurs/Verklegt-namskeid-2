﻿using System;
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
        public ActionResult Index()
        {
            List<AssignmentProjectViewModel> allProjects = _service.GetAllProjects();
            return View(allProjects);
        }

        /*[HttpGet]
        public ActionResult Create()
        {
            ViewBag.AssignmentList = GetAssignmentID();
            return View();
        }*/

        [HttpGet]
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


        public ActionResult Save(AssignmentProjectViewModel viewModel)
        {
            _service.AddToDB(viewModel);

            return RedirectToAction("Details", "Assignments", new { id = viewModel.AssignmentID });
        }

        private List<SelectListItem> GetAssignmentID()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            AssignmentsService assignments = new AssignmentsService();
            result.AddRange(assignments.GetAllAssignments().Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.AssignmentName }));

            return result;
        }


        [HttpGet]
        public ActionResult UnfinishedProjects()
        {
            List<AssignmentProjectViewModel> projects = _service.GetAllProjects();
            return View(projects);
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
      

        public ActionResult Delete(int id, int assignmentId)
        {
            _service.DeleteProjectById(id);

            return RedirectToAction("Details", "Assignments", new { id = assignmentId });

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