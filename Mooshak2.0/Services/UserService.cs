using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.VisualBasic.ApplicationServices;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;


namespace Mooshak2._0.Services
{
    public class UserService
    {
        private ApplicationDbContext _db;

        public UserService()
        {
            _db = new ApplicationDbContext();
        }

        public List<UserViewModel> GetAllUsers()
        {
            List<ApplicationUser> users = _db.Users.ToList();
            List <UserViewModel> viewModel = new List<UserViewModel>();

            foreach (var tmp in users)
            {
                viewModel.Add(new UserViewModel()
                {
                    FullName = tmp.FullName,
                    SSN = tmp.SSN,
                    Email = tmp.Email,

                });
            }

            return viewModel;
        }
    }
}