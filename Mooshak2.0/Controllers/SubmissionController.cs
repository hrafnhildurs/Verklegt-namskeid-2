using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Services;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;

namespace Mooshak2._0.Controllers
{
    public class SubmissionController : Controller
    {
        [HttpGet]
        public ActionResult Submit()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Submit(string code)
        {
            
            return View();
        }
        public ActionResult Export(int StudentID, int ProjectID)
        {
            return View();
        }



    }
}