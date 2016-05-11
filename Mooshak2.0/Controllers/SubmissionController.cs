using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Services;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System.IO;

namespace Mooshak2._0.Controllers
{
    public class SubmissionController : Controller
    {
        private AssignmentProjectService _service = new AssignmentProjectService();

        [HttpGet]
        public ActionResult Submit()
        {

            return View();
        }
        //Fékk þennann kóða hér : http://haacked.com/archive/2010/07/16/uploading-files-with-aspnetmvc.aspx/
        [HttpPost]
        public ActionResult Submit(HttpPostedFileBase file)
        {
            if(file == null)
            {
                //TODO
                //Kasta villu
            }

            else if(file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Submit");
        }
        public ActionResult Export(int StudentID, int ProjectID)
        {
            return View();
        }



    }
}