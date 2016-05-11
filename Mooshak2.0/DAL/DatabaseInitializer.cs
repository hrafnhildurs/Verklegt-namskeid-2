using Mooshak2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2._0.DAL
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            
        }
    }
}