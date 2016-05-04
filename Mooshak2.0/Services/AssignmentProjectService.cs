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
        public AssignmentProjectViewModel AddToDB()
        {
            AssignmentProjectViewModel model = new AssignmentProjectViewModel();
            model.ProjectName = "";
            model.Weight = 0;
            model.Description = "";

            return model;

        }

        public AssignmentProjectViewModel AddToDB(AssignmentProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                AssignmentProjectViewModel newProject = new AssignmentProjectViewModel()
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    Weight = model.Weight
                };

                _db.Projects.Add(newProject);
                _db.SaveChanges();
                return newProject;
            }

            model.ProjectName = "";
            model.Weight = 0;
            model.Description = "";
            return model;

        }

        public AssignmentProjectViewModel GetProjectByID(int ID)
        {
            AssignmentProjectViewModel result = (from project in _db.Projects
                            where project.ID == ID
                            select project).SingleOrDefault();

            return result;
        }

        public AssignmentProjectViewModel GetProjectsInAssignment(int AssignmentID)
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