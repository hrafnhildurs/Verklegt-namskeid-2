using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Mooshak2._0.Models;
using Mooshak2._0.Models.Entities;
using System.Data.Entity.Validation;

namespace Mooshak2._0.Services
{
    public class CourseService
    {
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
                Semester = viewModel.Semester
            };
            _db.Courses.Add(model);
            _db.SaveChanges();
        }


        public CourseViewModel GetCourseByID(int courseId)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseId);
            if (course == null)
            {
                //TODO: kasta villu                                                                                    
            }

            var viewModel = new CourseViewModel
            {
                CourseID =  course.ID,
                CourseNumber = course.CourseNumber,
                CourseName = course.CourseName,
                Semester = course.Semester,

                //Students = course.Students
                
            };

            return viewModel;
        }

        
        public void DeleteCourseByID(int courseId)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseId);
            if (course == null)
            {
                //TODO: kasta villu                                                                                    
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        // returns a list of all courses registered in the db.
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

        public void EditCourseById(CourseViewModel viewModel)
        {
            var model = _db.Courses.Where(x => x.ID == viewModel.CourseID).SingleOrDefault();
            if (model == null)
            {
                //TODO: kasta villu                                                                                    
            }
            
            model.CourseName = viewModel.CourseName;
            model.CourseNumber = viewModel.CourseNumber;
            model.Semester = viewModel.Semester;


           _db.SaveChanges();
        }
    }
}