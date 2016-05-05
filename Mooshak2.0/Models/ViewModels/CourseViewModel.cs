using System;
using System.Collections.Generic;
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
        
        public List<CourseViewModel> courses { get; set; }
    }
}