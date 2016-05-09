using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.VisualBasic.ApplicationServices;
using Mooshak2._0.Migrations;
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
            ManageRoles man = new ManageRoles();
            List<ApplicationUser> users = _db.Users.ToList();
            List<UserViewModel> viewModel = new List<UserViewModel>();

            foreach (var tmp in users)
            {
                viewModel.Add(new UserViewModel()
                {
                    FullName = tmp.FullName,
                    SSN = tmp.SSN,
                    Email = tmp.Email,
                    UserRole = man.GetUserRole(tmp.FullName)
                });
            }

            return viewModel;
        }

        public List<UserViewModel> GetSortedUsers(string role)
        {
            ManageRoles man = new ManageRoles();

            List<UserViewModel> viewModel = new List<UserViewModel>();
            List<ApplicationUser> users = _db.Users.ToList();

            foreach (var tmp in users)
            {
                if (man.UserIsInRole(tmp.Id, role))
                {
                    viewModel.Add(new UserViewModel()
                    {
                        FullName = tmp.FullName,
                        SSN = tmp.SSN,
                        Email = tmp.Email,
                        UserRole = man.GetUserRole(tmp.FullName)
                    });
                }
                ;
            }

            return viewModel;
        }

        public UserViewModel GetUserByID(int userId)
        {
            ManageRoles man = new ManageRoles();
            var user = _db.Users.SingleOrDefault(x => x.Id == userId.ToString());
            if (user == null)
            {
                //TODO: kasta villu                                                                                    
            }

            var viewModel = new UserViewModel
            {
                FullName = user.FullName,
                SSN = user.SSN,
                Email = user.Email,
                UserRole = man.GetUserRole(user.FullName)
            };

            return viewModel;
        }

        public void EditUserById(UserViewModel viewModel)
        {
            var model = _db.Users.Where(x => x.Id == viewModel.UserID.ToString()).SingleOrDefault();

            if (model == null)
            {
                //TODO: kasta villu                                                                                    
            }

            if (model != null)
            {
                model.FullName = viewModel.FullName;
                model.SSN = viewModel.SSN;
                model.Email = viewModel.Email;
            }


            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("Entity {0} in state {1} has validation errors:",
                        error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        Console.WriteLine("\tProperty: {0}, Error: {1}",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                    Console.WriteLine();
                }
                throw;
            }
        }
    }
}