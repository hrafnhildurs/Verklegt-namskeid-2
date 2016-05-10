using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.ViewModels;

namespace Mooshak2._0.Models.Entities
{
    public class Course
    {
        /// <summary>
        /// The database-generated unique ID of the course.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The number of the course in the RU course catalogue.
        /// </summary>
        public string CourseNumber { get; set; }

        /// <summary>
        /// The name of the course
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// The semester the course is being taught
        /// </summary>
        public string Semester { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }
    }
}