﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string assignmentTitle { get; set; }
        public List<AssignmentProjectViewModel> projectDescription { get; internal set; }
        public List<AssignmentProjectViewModel> Projects { get; set; }
    }
}