using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class DbSessionFactory
    {
        public static   IDbSession GetCurrentDbSession()
        {
            var db = CallContext.GetData("DbSessionFactory") as DbSession;
            if (db == null)
            {
                db = new DbSession();
                CallContext.SetData("DbSessionFactory", db);
            }
            return db;
        }
    }
}
