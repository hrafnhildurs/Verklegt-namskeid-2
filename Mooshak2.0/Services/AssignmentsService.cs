using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                    projectTitle = x.ProjectName
                }).ToList();

            //get the description for the projects that are a part of this assignment
            var description = _db.Projects.Where(x => x.AssignmentID == assignmentID).
                Select(x => new AssignmentProjectViewModel
                {
                    projectDescription = x.Description
                }).ToList();

            //make new viewModel
            var viewModel = new AssignmentViewModel
            {
                assignmentTitle = assignment.AssignmentName,
                Projects = projects,
                projectDescription =  description
            };

            //return the viewModel
            return viewModel;
        }

        public AssignmentViewModel DeleteAssignmentByID(int id)
        {
            //TODO:
            return null;
        }
    }
}