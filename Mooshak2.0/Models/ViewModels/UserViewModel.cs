using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2._0.Models.Entities;

namespace Mooshak2._0.Models.ViewModels
{
    public class UserViewModel
    {
        public string FullName { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }

        //public virtual ICollection<Course> Courses { get; set; }


        //public List<Course> Courses { get; set; }
    }

}