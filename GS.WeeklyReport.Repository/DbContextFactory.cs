using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Repository
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext db = CallContext.GetData("DbContextFactory") as DbContext;

            if (db == null)
            {
                db = new Entities();
                CallContext.SetData("DbContextFactory", db);
            }

            return db;
        }
    }
}
