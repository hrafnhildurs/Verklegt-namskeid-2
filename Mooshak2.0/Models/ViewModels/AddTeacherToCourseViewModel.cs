﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class AddTeacherToCourseViewModel
    {
        public int CourseID { get; set; }
        public string StudentID { get; set; }
        public List<UserViewModel> AvailableTeachers { get; set; }
    }
}