using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public List<ApplicationUser> Students { get; set; }

    }
}