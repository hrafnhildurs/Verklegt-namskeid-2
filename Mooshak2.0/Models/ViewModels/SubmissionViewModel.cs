using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int AssignmentID { get; set; }
        public string StudentID { get; set; }
        public string SubmittedCode { get; set; }
        public int ProjectID { get; set; }
        public DateTime Date { get; set; }
        public string SubmissionOutput { get; set; }
        public string ExpectedSubmissionOutput { get; set; }
        public string Input { get; set; }
        public string Result { get; set; }
       /// public List<UserViewModel> StudentList { get; set; }

       // public List<SubmissionViewModel> Submissions { get; set; }

    }
}