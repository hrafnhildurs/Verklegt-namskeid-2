using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Mooshak2._0.Models.Entities;
using Mooshak2._0.Models;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;


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

            if (project != null)
            {
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
            else
            {
                throw new ArgumentNullException();
            }
        }

        internal SubmissionViewModel CompileCode(SubmissionViewModel Model)
        {
            


            var workingFolder = "C:\\Temp\\Mooshak2Code\\";
            var cppFileName = "Hello.cpp";
            var exeFilePath = workingFolder + "Hello.exe";

            // Write the code to a file, such that the compiler
            // can find it:
            System.IO.File.WriteAllText(workingFolder + cppFileName, Model.SubmittedCode);

            // In this case, we use the C++ compiler (cl.exe) which ships
            // with Visual Studio. It is located in this folder:
            var compilerFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";
            // There is a bit more to executing the compiler than
            // just calling cl.exe. In order for it to be able to know
            // where to find #include-d files (such as <iostream>),
            // we need to add certain folders to the PATH.
            // There is a .bat file which does that, and it is
            // located in the same folder as cl.exe, so we need to execute
            // that .bat file first.

            // Using this approach means that:
            // * the computer running our web application must have
            //   Visual Studio installed. This is an assumption we can
            //   make in this project.
            // * Hardcoding the path to the compiler is not an optimal
            //   solution. A better approach is to store the path in
            //   web.config, and access that value using ConfigurationManager.AppSettings.

            // Execute the compiler:
            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;

            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + cppFileName);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();

            // Check if the compile succeeded, and if it did,
            // we try to execute the code:
            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;
                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();
                    // In this example, we don't try to pass any input
                    // to the program, but that is of course also
                    // necessary. We would do that here, using
                    // processExe.StandardInput.WriteLine(), similar
                    // to above.

                    // We then read the output of the program:
                    var lines = new List<string>();
                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        lines.Add(processExe.StandardOutput.ReadLine());
                    }

                    Model.SubmissionOutput = string.Join(" ", lines.ToArray());
                }
            }

            // TODO: We might want to clean up after the process, there
            // may be files we should delete etc.
            return Model;
    }

        internal List<SubmissionViewModel> GetAllSubmissions()
        {
            List<Submission> submissions = _db.Submissions.ToList();
            List<SubmissionViewModel> viewModel = new List<SubmissionViewModel>();

            foreach (var tmp in submissions)
            {
                viewModel.Add(new SubmissionViewModel()
                {
                    AssignmentID = tmp.AssignmentID,
                    Date = DateTime.Now,
                    ProjectID = tmp.ProjectID,
                    StudentID = tmp.StudentID,
                    Result = tmp.Result,
                    SubmittedCode = tmp.SubmittedCode

                });
            }

            return viewModel;
        }

        public List<AssignmentProjectViewModel> GetAllUnfinishedProjects()
        {
            List<AssignmentProject> project = _db.Projects.ToList();
            List<AssignmentProjectViewModel> viewModel = new List<AssignmentProjectViewModel>();

            if (project != null)
            {
               foreach (var tmp in project.Where(x => x.Submitted == false))
            {
                    var assignment = _db.Assignments.SingleOrDefault(x => x.ID == tmp.AssignmentID);
                    var course = _db.Courses.SingleOrDefault(x => x.ID == tmp.CourseID);
                    viewModel.Add(new AssignmentProjectViewModel()
                    {
                        ID = tmp.ID,
                        ProjectName = tmp.ProjectName,
                        CourseName = course != null ? course.CourseName : "No course!",
                        AssignmentName = assignment != null ? assignment.AssignmentName : "No assignment!",
                        AssignmentID = assignment != null ? assignment.ID : 0,
                        Description = tmp.Description,
                        Weight = tmp.Weight,
                        Deadline = tmp.Deadline
                    });
                }
                return viewModel; 
            }
            else
            {
                throw new ArgumentNullException();
            }
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
            else
            {
                throw new ArgumentNullException();
            }
        }

        public AssignmentProjectViewModel GetProjectByID(int projectID)
        {
            var project = _db.Projects.SingleOrDefault(x => x.ID == projectID);
            if (project != null)
            {
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
            else
            {
                throw new ArgumentNullException();
            }


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
            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void SaveCodeToDb(SubmissionViewModel viewModel)
        {
            SubmissionViewModel Model = CompileCode(viewModel);
            if (Model != null)
            {

                var model = new Submission
                {
                    AssignmentID = Model.AssignmentID,
                    Date = DateTime.Now,
                    ProjectID = Model.ProjectID,
                    StudentID = Model.StudentID,
                    Result = Model.Result,
                    SubmittedCode = Model.SubmittedCode,
                    SubmissionOutput  = Model.SubmissionOutput

                };
                _db.Submissions.Add(model);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public SubmissionViewModel ExportSubmissionByID(int? ID)
        {
            var submission = _db.Submissions.SingleOrDefault(x => x.ID == ID);

            //if the project doesn't exist
            if (submission != null)
            {
                var viewModel = new SubmissionViewModel()
                {
                    Date = submission.Date,
                    StudentID = submission.StudentID,
                    ProjectID = submission.ProjectID,
                    SubmittedCode = submission.SubmittedCode
                };
                return viewModel;
            }
            else
            {
                throw new ArgumentNullException();
            } 
        }
        
    }
}


