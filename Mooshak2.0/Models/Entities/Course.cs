using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.Models.Entities
{
    public class Course
    {
        /// <summary>
        /// The database-generated unique ID of the course.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the course
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// The semester the course is bein taught
        /// </summary>
        public string Semester { get; set; }
    }
}