using System;

namespace Mooshak2._0.Models.Entities
{
    public class Assignment
    {
        /// <summary>
        /// The database-generated unique ID of the assignment.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A foreign key to the course
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// The name of the assignment. Example: "Assignment1".
        /// </summary>
        public string AssignmentName { get; set; }

        /// <summary>
        /// The deadline of the assignment
        /// </summary>
        public DateTime Deadline { get; set; }

    }
}