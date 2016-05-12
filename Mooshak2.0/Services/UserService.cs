using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using Mooshak2._0.Models.Entities;

namespace Mooshak2._0.Services
{
    public class UserService
    {
        //Instance of DbContext
        private ApplicationDbContext _db;

        public UserService()
        {
            _db = new ApplicationDbContext();
        }

        

        public List<UserViewModel> GetAllUsers()
        {
            //Instance of the ManageRoles class to get the user's role
            ManageRoles man = new ManageRoles();
            //A list of all the users in the database
            List<ApplicationUser> users = _db.Users.ToList();
            //List of view models to return
            List<UserViewModel> viewModel = new List<UserViewModel>();

            //Get all the users from the list and adding them to te view model
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
            //return the list of view models
            return viewModel;
        }

        public List<UserViewModel> GetSortedUsers(string role)
        {
            //Instance of the ManageRoles class to get the user's role
            ManageRoles man = new ManageRoles();
            //List of view models to return
            List<UserViewModel> viewModel = new List<UserViewModel>();
            //A list of all the users in the database
            List<ApplicationUser> users = _db.Users.ToList();

            //Get all the users from the list with the right role and adding them to te view model
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
            //Return the view model
            return viewModel;
        }

        public UserViewModel GetUserBySSN(string userSSN)
        {
            //Instance of the ManageRoles class to get the user's role
            ManageRoles man = new ManageRoles();
            //Get the right user from the database
            var user = _db.Users.Where(x => x.SSN == userSSN).FirstOrDefault();
            
            //if the user exists add him to a view model and return it, otherwise throw exception
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
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void EditUserBySSN(UserViewModel user)
        {
            //Instance of the ManageRoles class to get the user's role
            ManageRoles man = new ManageRoles();
            //Find the right user
            var model = _db.Users.Where(x => x.SSN == user.SSN).FirstOrDefault();
            
            //If the user dosn't exist throw an exception otherwise change the user information
            if (model == null)
            {
                //TODO: kasta villu 
                throw new ArgumentNullException();
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
            //Find the right user
            var user = _db.Users.Where(x => x.SSN == userSSN).FirstOrDefault();

            //if the user dosn't exist thorw an exception, otherwise remove the user from the database
            if (user == null)
            {
                //TODO: kasta villu       
                throw new ArgumentNullException();
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public bool CheckIfUserExist(string userSSN)
        {
            //Search for user, return true if found, otherwise false
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
            //Find the right student
            ApplicationUser studentToAdd = (from user in _db.Users where user.Id == studentId select user).SingleOrDefault();
            //Find the right course
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();
            
            //If both the student and the course exist, add the student to the course, otherwise throw an exception
            if (studentToAdd != null && courseToAdd != null)
            {
                if (studentToAdd.Courses.Where(x => x.ID == courseId).Count() == 0)
                {
                    studentToAdd.Courses.Add(courseToAdd);
                    _db.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void RemoveStudentFromCourse(int courseId, string studentId)
        {
            //Find the right student
            ApplicationUser studentToRemove = (from user in _db.Users where user.Id == studentId select user).SingleOrDefault();
            //Find the right course
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();

            //If both the student and the course are found, remove the student from the course, otherwise throw an exception
            if (studentToRemove != null && courseToAdd != null)
            {
                if (studentToRemove.Courses.Where(x => x.ID == courseId).Count() == 1)
                {
                    studentToRemove.Courses.Remove(courseToAdd);
                    _db.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

    }
}