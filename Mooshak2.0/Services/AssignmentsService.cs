using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;
using System.Web.Mvc;

namespace Mooshak2._0.Services
{
    public class AssignmentsService : AssignmentProjectService
    {
        //Instance of DbContext
        private ApplicationDbContext _db;

        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }

        public List<AssignmentViewModel> GetAllAssignments()
        {
            List<Assignment> assignment = _db.Assignments.ToList();
            List<AssignmentViewModel> viewModel = new List<AssignmentViewModel>();

            foreach (var tmp in assignment)
            {
                var course = _db.Courses.SingleOrDefault(x => x.ID == tmp.CourseID);
                viewModel.Add(new AssignmentViewModel()
                {
                    ID = tmp.ID,
                    CourseID = tmp.CourseID,
                    AssignmentName = tmp.AssignmentName,
                    Deadline = tmp.Deadline,
                    Course =  course
                });
            }

            return viewModel;
        }

        public List<AssignmentViewModel> GetAssignmentsInCourse(int courseID)
        {
            //TODO:
            return null;
        }

        public AssignmentViewModel GetAssignmentByID (int assignmentID)
        {
            //get the assignment
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            var course = _db.Courses.SingleOrDefault(x => x.ID == assignment.CourseID);

            //if the assignment doesn't exist
            if (assignment == null)
            {
                throw new InvalidDataException();
            }

            //get the projects that are a part of this assignment
            var projects = _db.Projects.Where(x => x.AssignmentID == assignmentID).
                Select(x => new AssignmentProjectViewModel
                {
                    ProjectName = x.ProjectName
                }).ToList();
            //make new viewModel
            var viewModel = new AssignmentViewModel
            {
                AssignmentName = assignment.AssignmentName,
                Course = course,
                CourseID = assignment.CourseID,
                Deadline = assignment.Deadline
                //Projects = projects,
                //projectDescription =  description
            };

            //return the viewModel
            return viewModel;
        }
        
        public void DeleteAssignmentByID(int? assignmentID)
        {
            if(assignmentID.HasValue)
            {
                Assignment assignment = _db.Assignments.Where(x => x.ID == assignmentID.Value).SingleOrDefault();
                if (assignment != null)
                {
                    _db.Assignments.Remove(assignment);
                    _db.SaveChanges();
                }
            }
            else
            {
                //kasta Villu
            }

        }

        public void AddToDB(AssignmentViewModel viewModel)
        {
            var model = new Assignment
            {
                AssignmentName = viewModel.AssignmentName,
                CourseID = viewModel.CourseID,
                Deadline = viewModel.Deadline,
               // AssignmentProjects = viewModel.Projects.ToList()
            };
            _db.Assignments.Add(model);
            _db.SaveChanges();
        }

        public AssignmentViewModel CreateAssignment(int CourseId)
        {
            //TODO:
            return null;
        }

        public void EditAssignmentById(int? id, AssignmentViewModel model)
        {
            if (id.HasValue)
            {
                Assignment assignment = _db.Assignments.Where(x => x.ID == id.Value).SingleOrDefault();
                if (assignment != null)
                {
                    assignment.CourseID = model.CourseID;
                    assignment.Deadline = model.Deadline;
                    assignment.AssignmentName = model.AssignmentName;
                    _db.SaveChanges();
                }
            }
            else
            {
                //kasta villu!
            }
        }

    }
}