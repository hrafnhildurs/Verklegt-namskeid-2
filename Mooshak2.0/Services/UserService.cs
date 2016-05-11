using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Models.Entities;

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
                    Id = tmp.Id,
                    FullName = tmp.FullName,
                    SSN = tmp.SSN,
                    Email = tmp.Email,
                    UserRole = man.GetUserRole(tmp.Email)
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
                        UserRole = man.GetUserRole(tmp.Email)
                    });
                }
                ;
            }

            return viewModel;
        }

        public UserViewModel GetUserBySSN(string userSSN)
        {
            ManageRoles man = new ManageRoles();
            var user = _db.Users.Where(x => x.SSN == userSSN).FirstOrDefault();

            if (user != null)
            {
                var viewModel = new UserViewModel
                {
                    FullName = user.FullName,
                    SSN = user.SSN,
                    Email = user.Email,
                    UserRole = man.GetUserRole(user.Email)
                };

                return viewModel;
            }

            return null;

        }

        public void EditUserBySSN(UserViewModel user)
        {   
            ManageRoles man = new ManageRoles();
            var model = _db.Users.Where(x => x.SSN == user.SSN).FirstOrDefault();
            if (model == null)
            {
                //TODO: kasta villu 
            }
            else
            {
                model.FullName = user.FullName;
                model.SSN = user.SSN;
                model.Email = user.Email;

                if (man.GetUserRole(model.Email) != null)
                {
                    man.ClearUserRoles(model.Id);
                }
                man.AddUserToRole(model.Id, user.UserRole);
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

        public void DeleteUserBySSN(string userSSN)
        {
            var user = _db.Users.Where(x => x.SSN == userSSN).FirstOrDefault();
            if (user == null)
            {
                //TODO: kasta villu                                                                                    
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public bool CheckIfUserExist(string userSSN)
        {
            var user = _db.Users.Where(x => x.SSN == userSSN).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        public void AddStudentToCourse(int courseId, string studentId)
        {
            ApplicationUser studentToAdd = (from user in _db.Users where user.Id == studentId select user).SingleOrDefault();
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();
            if (studentToAdd != null && courseToAdd != null)
            {
                if (studentToAdd.Courses.Where(x => x.ID == courseId).Count() == 0)
                {
                    studentToAdd.Courses.Add(courseToAdd);
                    _db.SaveChanges();
                }
            }
        }

        public void RemoveStudentFromCourse(int courseId, string studentId)
        {
            ApplicationUser studentToAdd = (from user in _db.Users where user.Id == studentId select user).SingleOrDefault();
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();
            if (studentToAdd != null && courseToAdd != null)
            {
                if (studentToAdd.Courses.Where(x => x.ID == courseId).Count() == 1)
                {
                    studentToAdd.Courses.Remove(courseToAdd);
                    _db.SaveChanges();
                }
            }

        }

    }
}