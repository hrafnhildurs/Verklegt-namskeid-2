using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;

namespace Mooshak2._0.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string AssignmentName { get; set; }
        public List<AssignmentProject> Projects { get; set; }
        public int ID { get; set; }
        public int CourseID { get; set; }
        public DateTime Deadline { get; set; }
    }
}