using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak2._0.Services;
using Mooshak2._0.Models;
using Mooshak2._0.Models.ViewModels;
using System.IO;
using System.Diagnostics;

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

            /*
            //Kóði sem fannst hér: https://code.msdn.microsoft.com/windowsdesktop/C-and-Python-interprocess-171378ee

            // full path of python interpreter  
            string python = @"C:\Users\darkb\AppData\Local\Programs\Python\Python35-32\python.exe";

            // python app to call  
            string myPythonApp = "sum.py";

            // dummy parameters to send Python script  
            int x = 2;
            int y = 5;

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            // start python app with 3 arguments  
            // 1st argument is pointer to itself, 2nd and 3rd are actual arguments we want to send 
            myProcessStartInfo.Arguments = myPythonApp + " " + x + " " + y;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();

            // wait exit signal from the app we called 
            myProcess.WaitForExit();

            // close the process 
            myProcess.Close();

            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/uploads/test.txt"), myString);

            */

            return RedirectToAction("Submit");
        }
        public ActionResult Export(int StudentID, int ProjectID)
        {
            return View();
        }



    }
}