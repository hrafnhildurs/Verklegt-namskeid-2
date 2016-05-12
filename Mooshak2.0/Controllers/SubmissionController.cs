﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Services;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNet.Identity;

namespace Mooshak2._0.Controllers
{
    public class SubmissionController : Controller
    {
        private AssignmentProjectService _service = new AssignmentProjectService();

        [HttpGet]
        public ActionResult Submit(int projectId, int assignmentId)
        {
            SubmissionViewModel model = new SubmissionViewModel();
            model.ProjectID = projectId;
            model.AssignmentID = assignmentId;
            return View(model);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Submit(SubmissionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.StudentID = User.Identity.GetUserId();
                _service.SaveCodeToDb(viewModel);
                return RedirectToAction("UnfinishedProjects", "AssignmentProject");
            }

            return View(viewModel);
        }
        public ActionResult Export(int StudentID, int ProjectID)
        {
            return View();
        }
    }
}