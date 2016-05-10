using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class AssignmentProjectViewModel
    {
        public int ID { get; set; }

        public int AssignmentID { get; set; }

        public string ProjectName { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }
        
        public string Deadline { get; set; }

        public int CourseID { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }
    }
}