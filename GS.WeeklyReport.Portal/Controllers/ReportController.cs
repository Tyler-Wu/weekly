using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /Report/
        public ActionResult Index()
        {
            return View();
        }
	}
}