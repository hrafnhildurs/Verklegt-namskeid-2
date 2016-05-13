using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Mooshak2._0.Services
{
    public class AssignmentsService : AssignmentProjectService
    {
        // instance of DbContext
        private ApplicationDbContext _db;

        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }

        // returns a list of all assignments
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

        // gets the assignment with the given ID, its projects, and the course the assignment belongs to
        public AssignmentViewModel GetAssignmentByID (int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            

            if (assignment == null)
            {
                throw new ArgumentNullException();
            }

            var course = _db.Courses.SingleOrDefault(x => x.ID == assignment.CourseID);
            var projects = _db.Projects.Where(x => x.AssignmentID == assignmentID).ToList();
               
            var viewModel = new AssignmentViewModel
            {
                ID = assignment.ID,
                AssignmentName = assignment.AssignmentName,
                Course = course,
                CourseID = assignment.CourseID,
                Deadline = assignment.Deadline,
                Projects = projects,
            };

            return viewModel;
        }

        // delete assignment with the given ID from the database
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
                throw new ArgumentNullException();
            }

        }

        // adds a new assignment to the database
        public void AddToDB(AssignmentViewModel viewModel)
        {
            var model = new Assignment
            {
                AssignmentName = viewModel.AssignmentName,
                CourseID = viewModel.CourseID,
                Deadline = viewModel.Deadline
            };
            _db.Assignments.Add(model);
            _db.SaveChanges();
        }

        // edits an assignment by ID and updates the database
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
                else
                {
                    throw new ArgumentNullException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

    }
}