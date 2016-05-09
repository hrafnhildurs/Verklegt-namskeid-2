using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mooshak2._0.Models;

namespace Mooshak2._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /// <summary>
            /// Creates the user roles when the application starts
            /// if they don't exist already
            /// </summary>
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
        }
    }
}
