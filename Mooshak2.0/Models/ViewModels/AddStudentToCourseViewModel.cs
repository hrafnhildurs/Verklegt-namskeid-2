using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2._0.Models.ViewModels
{
    public class AddStudentToCourseViewModel
    {
        public int CourseID { get; set; }
        public string StudentID { get; set; }
        public List<UserViewModel> AvailableStudents { get; set; }
    }
}