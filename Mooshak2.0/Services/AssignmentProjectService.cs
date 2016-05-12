﻿using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Mooshak2._0.Models.Entities;
using Mooshak2._0.Models;
using System.Web.Mvc;
using System.IO;

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

            if (project == null)
            {
                //TODO kassta villu
            }
            foreach (var tmp in project)
            {
                var assignment = _db.Assignments.SingleOrDefault(x => x.ID == tmp.AssignmentID);
                var course = _db.Courses.SingleOrDefault(x => x.ID == tmp.CourseID);
                viewModel.Add(new AssignmentProjectViewModel()
                {
                    ID = tmp.ID,
                    ProjectName = tmp.ProjectName,
                    CourseName = course != null ? course.CourseName : "No course!",
                    AssignmentName = assignment != null ? assignment.AssignmentName : "No assignment!",
                    Description = tmp.Description,
                    Weight = tmp.Weight,
                    Deadline = tmp.Deadline
                });
            }
            return viewModel;
        }

        public List<AssignmentProjectViewModel> GetAllUnfinishedProjects()
        {
            List<AssignmentProject> project = _db.Projects.ToList();
            List<AssignmentProjectViewModel> viewModel = new List<AssignmentProjectViewModel>();

            if(project == null)
            {
                //TODO kassta villu
            }
            foreach (var tmp in project.Where(x=>x.Submitted == false))
            {
                var assignment = _db.Assignments.SingleOrDefault(x => x.ID == tmp.AssignmentID);
                var course = _db.Courses.SingleOrDefault(x => x.ID == tmp.CourseID);
                 viewModel.Add(new AssignmentProjectViewModel()
                {
                    ID = tmp.ID,
                    ProjectName = tmp.ProjectName,
                    CourseName = course != null ? course.CourseName : "No course!",
                    AssignmentName = assignment != null ? assignment.AssignmentName : "No assignment!",
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
                    AssignmentID = viewModel.AssignmentID,
                    CourseID = viewModel.CourseID,
                    ProjectName = viewModel.ProjectName,
                    Description = viewModel.Description,
                    Weight = viewModel.Weight,
                    Deadline = new DateTime(2016, 1, 1, 23, 59, 59)
                };
                _db.Projects.Add(Model);
                _db.SaveChanges();
            }
        }

        public AssignmentProjectViewModel GetProjectByID(int projectID)
        {
            var project = _db.Projects.SingleOrDefault(x => x.ID == projectID);
            if (project == null)
            {
                //TODO: kasta villu                                                                                    
            }
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == project.AssignmentID);
            var course = _db.Courses.SingleOrDefault(x => x.ID == project.CourseID);
            var viewModel = new AssignmentProjectViewModel
            {
                ID = project.ID,
                CourseID = project.CourseID,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Weight = project.Weight,
                Deadline = project.Deadline,
                CourseName = course.CourseName,
                AssignmentName = assignment.AssignmentName,

            };

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

        public void DeleteProjectById(int id)
        {
            var project = _db.Projects.SingleOrDefault(x => x.ID == id);
            if (project == null)
            {
                throw new InvalidDataException();                                                                                  
            }
          
            _db.Projects.Remove(project);
            _db.SaveChanges();
             
        }

        public void SubmitCode(String submissionCode)
        {

            
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
      }   }
}

