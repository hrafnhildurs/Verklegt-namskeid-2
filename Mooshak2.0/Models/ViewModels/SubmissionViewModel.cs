﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public string SubmittedCode { get; set; }
        public int ProjectID { get; set; }
        public string Date { get; set; }
        public bool Result { get; set; }

        public List<SubmissionViewModel> Submissions { get; set; }

    }
}