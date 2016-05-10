using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Mooshak2._0.Models.Entities;
using Mooshak2._0.Models;
using System.Web.Mvc;

namespace Mooshak2._0.Services
{
    public class AssignmentProjectService
    {
        //Instance of DBContext
        private ApplicationDbContext _db;
        public AssignmentProjectService()
        {
            _db = new ApplicationDbContext();
        }

        public List<AssignmentProjectViewModel> GetAllProjects()
        {
            List<AssignmentProject> project = _db.Projects.ToList();
            List<AssignmentProjectViewModel> viewModel = new List<AssignmentProjectViewModel>();

            foreach (var tmp in project)
            {
                viewModel.Add(new AssignmentProjectViewModel()
                {
                    ProjectName = tmp.ProjectName,
                    Description = tmp.Description,
                    Weight = tmp.Weight,
                    Deadline = tmp.Deadline            

                });
            }
            return viewModel;
        }

        public void AddToDB(AssignmentProjectViewModel viewModel)
        {
            if (viewModel != null)
            {
                AssignmentProject Model = new AssignmentProject
                {
                    CourseID = viewModel.CourseID,
                    ProjectName = viewModel.ProjectName,
                    Description = viewModel.Description,
                    Weight = viewModel.Weight,
                    Deadline = viewModel.Deadline
                };
                _db.Projects.Add(Model);
                _db.SaveChanges();
            }
        }

        public AssignmentProjectViewModel GetProjectByID(int ID)
        {
            //get the project
            var project = _db.Projects.SingleOrDefault(x => x.ID == ID);

            //if the project doesn't exist
            if (project == null)
            {
                //TODO: kasta villu!
            }


            var viewModel = new AssignmentProjectViewModel()
            {
                ProjectName = project.ProjectName,
            };

            //return the viewModel
            return viewModel;
        }

        public List<AssignmentProjectViewModel> GetProjectsInAssignment(int AssignmentID)
        {
            //get the projects that are a part of this assignment
            var projects = _db.Projects.Where(x => x.AssignmentID == AssignmentID).
                Select(x => new AssignmentProjectViewModel
                {
                    ProjectName = x.ProjectName
                }).ToList();

            //return the viewModel
            return projects;
        }

        public void DeleteProjectByID(int? ID)
        {
            //if ID exists
            if (ID.HasValue)
            {
                //find the project and assign it to instance
                AssignmentProject project = _db.Projects.Where(x => x.ID == ID).SingleOrDefault();
                if (project != null)
                {
                    //delete it from the database
                    _db.Projects.Remove(project);
                    _db.SaveChanges();
                }
            }
        }

        public void SubmitCode(Submission submission)
        {
            if (submission != null)
            {
                Submission newSub = new Submission
                {
                    Date = submission.Date,
                    StudentID = submission.StudentID,
                    ProjectID = submission.ProjectID,
                    SubmittedCode = submission.SubmittedCode
                };
                _db.Submissions.Add(newSub);
                _db.SaveChanges();
            }
        }
        public SubmissionViewModel ExportSubmissionByID(int? ID)
        {
            var submission = _db.Submissions.SingleOrDefault(x => x.ID == ID);

            //if the project doesn't exist
            if (submission == null)
            {
                //TODO: kasta villu!
            }

            var viewModel = new SubmissionViewModel()
            {
                Date = submission.Date,
                StudentID = submission.StudentID,
                ProjectID = submission.ProjectID,
                SubmittedCode = submission.SubmittedCode
            };

            return viewModel;
        }
    }
}

