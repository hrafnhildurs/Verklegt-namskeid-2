using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Models;

namespace Mooshak2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ManageRoles manager = new ManageRoles();
            if (!manager.RoleExists("Administrator"))
            {
                manager.CreateRole("Administrator");
            }
            if (!manager.RoleExists("Student"))
            {
                manager.CreateRole("Student");
            }
            if (!manager.RoleExists("Teacher"))
            {
                manager.CreateRole("Teacher");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}