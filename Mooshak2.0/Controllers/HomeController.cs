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
            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "User");
            }
            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Delete", "User");
            }
            if (User.IsInRole("Student"))
            {
                return RedirectToAction("Edit", "User");
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