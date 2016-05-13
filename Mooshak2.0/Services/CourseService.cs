using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Mooshak2._0.Models;
using Mooshak2._0.Models.Entities;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;

namespace Mooshak2._0.Services
{
    public class CourseService
    {
        // creates a connection to the database
        private ApplicationDbContext _db;

        public CourseService()
        {
            _db = new ApplicationDbContext();
        }

        // adds a course to the database
        public void AddToDB(CourseViewModel viewModel)
        {
            var model = new Course
            {
                CourseName = viewModel.CourseName,
                CourseNumber = viewModel.CourseNumber,
                Semester = viewModel.Semester,
                TeacherId = viewModel.TeacherID
            };
            _db.Courses.Add(model);
            _db.SaveChanges();
        }

        // gets a course from the database by ID and returns a courseViewModel
        public CourseViewModel GetCourseByID(int courseId)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseId);
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            var teacherName = "Not assigned";
            if (course.TeacherId != null)
            {
                var user = _db.Users.FirstOrDefault(x => x.Id == course.TeacherId);
                if (user != null)
                    teacherName = user.FullName;
            }

            var viewModel = new CourseViewModel
            {
                CourseID =  course.ID,
                CourseNumber = course.CourseNumber,
                CourseName = course.CourseName,
                Semester = course.Semester,
                TeacherID = course.TeacherId,
                TeacherName = teacherName,
                Students = course.Students.ToList()
            };

            return viewModel;
        }

        // deletes a course from the database by ID
        public void DeleteCourseByID(int courseId)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseId);
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        // gets all courses registered in the database and returns a list of courseViewModels
        public List<CourseViewModel> GetAllCourses()
        {
            List<Course> courses = _db.Courses.ToList();
            List<CourseViewModel> viewModel = new List<CourseViewModel>();

            foreach (var tmp in courses)
            {
                viewModel.Add(new CourseViewModel()
                {
                    CourseID = tmp.ID,
                    CourseNumber = tmp.CourseNumber,
                    CourseName = tmp.CourseName,
                    Semester = tmp.Semester

                });
            }

            return viewModel;
        }

        // edits a course by ID and updates the database
        public void EditCourseById(CourseViewModel viewModel)
        {
            var model = _db.Courses.Where(x => x.ID == viewModel.CourseID).SingleOrDefault();
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            
            model.CourseName = viewModel.CourseName;
            model.CourseNumber = viewModel.CourseNumber;
            model.Semester = viewModel.Semester;
            model.TeacherId = viewModel.TeacherID;

           _db.SaveChanges();
        }
    }
}