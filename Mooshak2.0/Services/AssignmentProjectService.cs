using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;
using Mooshak2._0.Models;
using System.Web.Mvc;

namespace Mooshak2._0.Services
{
    public class AssignmentProjectService
    {
        //Instance of DbContext
        private ApplicationDbContext _db;
        public AssignmentProjectService()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult AddToDB()
        {
            AssignmentProject model = new AssignmentProject();
            model.ProjectName = "";
            model.Weight = 0;
            model.Description = "";

            return View(model);

        }

        [HttpPost]
        public ActionResult AddToDB(AssignmentProject model)
        {
            if (ModelState.IsValid)
            {
                AssignmentProject newProject = new AssignmentProject()
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    Weight = model.Weight
                };

                _db.Projects.Add(newProject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.ProjectName = "";
            model.Weight = 0;
            model.Description = "";
            return View(model);

        }

        public AssignmentProject GetProjectByID(int ID)
        {
            AssignmentProject result = (from project in _db.Projects
                            where project.ID == ID
                            select project).SingleOrDefault();

            return result;
        }

        public AssignmentProject GetProjectsInAssignment(int AssignmentID)
        {
            var result = (from project in _db.Projects
                                        where project.ID == AssignmentID
                                        select project).ToList();

            return result;
        }
        /*
            GetProjectsInAssignment
            DeleteProjectByID
            SubmitByID
            ExportByID
        */

    }
}