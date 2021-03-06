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
    [Authorize(Roles = "Administrator, Student")]
    public class SubmissionController : Controller
    {
        private AssignmentProjectService _service = new AssignmentProjectService();

        [HttpGet]
        public ActionResult Submit(int projectId, int assignmentId, string input, string output)
        {
            SubmissionViewModel model = new SubmissionViewModel();
            model.ProjectID = projectId;
            model.AssignmentID = assignmentId;
            model.Input = input;
            model.ExpectedSubmissionOutput = output;


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

               

                return RedirectToAction("ViewSubmissions", "Submission");
            }

            return View(viewModel);
        }

        public ActionResult Export(int StudentID, int ProjectID)
        {
            return View();
        }
        public ActionResult ViewSubmissions()
        {
            List<SubmissionViewModel> allSubmissions = _service.GetAllSubmissions();
            return View(allSubmissions);
        }


        /*public ActionResult ViewSubmissionOutput(SubmissionViewModel viewModel)
        {
            SubmissionViewModel submissionOutput = _service.CompileCode(viewModel);
            return View(submissionOutput);
        }*/
    }
}