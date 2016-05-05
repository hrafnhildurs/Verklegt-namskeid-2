using Mooshak2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models;
using Mooshak2._0.Models.Entities;

namespace Mooshak2._0.Services
{
    public class CourseService
    {
        private ApplicationDbContext _db;

        public CourseService()
        {
            _db = new ApplicationDbContext();
        }

        public CourseViewModel AddToDB()
        {
            //TODO:
            return null;
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
                CourseNumber = course.CourseNumber,
                CourseName = course.CourseName
            };

            return viewModel;
        }


        public CourseViewModel DeleteCourseByID(int courseId)
        {
            //TODO:
            return null;
        }

        //returns a list of all courses registered in the db for a given semester
        public List<CourseViewModel> GetAllCourses()
        {
            List<Course> courses = _db.Courses.ToList();
            List<CourseViewModel> viewModel = new List<CourseViewModel>();

            foreach (var tmp in courses)
            {
                viewModel.Add(new CourseViewModel() { CourseName = tmp.CourseName });
            }

            return viewModel;
        }
    }
}