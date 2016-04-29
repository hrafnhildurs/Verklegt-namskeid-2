﻿
namespace Mooshak2._0.Models.Entities
{
    /// <summary>
    /// An AssignmentProject represents a part of an assignment.
    /// Each assignment may contain muliple projects, where
    /// each poject weight certain percentage of the final grade
    /// of the assiignment
    /// </summary>
    public class AssignmentProject
    {
        /// <summary>
        /// The database-generated unique ID of the project.
        /// </summary>
        public int ID { get; set; } 
        
        /// <summary>
        /// A foreign key to the assignment
        /// </summary>
        public int AssignmentID { get; set; }

        /// <summary>
        /// The name of the project. Example: "Part1".
        /// </summary>
        public string projectTitle { get; set; }
        
        /// <summary>
        /// Determines how much this project weights in the assignment.
        /// Example: if this project is 20% of the grade of the assignment,
        /// then this property contains the value 20.
        /// </summary>
        public int projectWeight { get; set; }

        /// <summary>
        /// Description of what the project is about
        /// </summary>
        public string projectDescription { get; set; }
    }
}