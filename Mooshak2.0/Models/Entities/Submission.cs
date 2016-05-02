using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.Entities
{
    public class Submission
    {
        /// <summary>
        /// The database-generated unique ID of the Submission.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The date of the submission
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// A foreign key to the student that is submitting
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// A foreign key to the project
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// The solution that is being submitted
        /// </summary>
        public string SubmittedCode { get; set; }

        /// <summary>
        /// Is the solution accepted or not
        /// </summary>
        public bool Result { get; set; }
    }
}