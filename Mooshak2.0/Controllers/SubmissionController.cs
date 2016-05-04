using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2._0.Controllers
{
    public class SubmissionController : Controller
    {
        public ActionResult Submit(int UserID, int ProjectID)
        {
            return View();
        }
        public ActionResult Export(int UserID, int ProjectID)
        {
            return View();
        }

    }
}