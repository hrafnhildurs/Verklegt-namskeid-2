using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;
using System.Web.Mvc;

namespace Mooshak2._0.Services
{
    public class AssignmentsService
    {
        //Instance of DbContext
        private ApplicationDbContext _db;
        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }

        public List<AssignmentViewModel> GetAllAssignments()
        {
            List<Assignment> assignments = _db.Assignments.ToList();

            List<AssignmentViewModel> result = new List<AssignmentViewModel>();

            foreach (var tmp in assignments)
            {
                result.Add(new AssignmentViewModel() { AssignmentName = tmp.AssignmentName });
            }

            return result;
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

            //if the assignment doesn't exist
            if (assignment == null)
            {
                //TODO: kasta villu!
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
                Projects = projects,
                //projectDescription =  description
            };

            //return the viewModel
            return viewModel;
        }
        //er ekki alveg viss hvað er að gerast hérna ... hverju á ég að returna ??
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

        public AssignmentViewModel AddToDB(int id)
        {
            //TODO:
            return null;
        }

        public AssignmentViewModel CreateAssignmentByID(int id)
        {
            //TODO:
            return null;
        }

        public void EditAssignmentByID(int? id, AssignmentViewModel model)
        {
            if (id.HasValue)
            {
                Assignment assignment = _db.Assignments.Where(x => x.ID == id.Value).SingleOrDefault();
                if (assignment != null)
                {
                    model.CourseID = assignment.CourseID;
                    model.Deadline = assignment.Deadline;
                    model.AssignmentName = assignment.AssignmentName;
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