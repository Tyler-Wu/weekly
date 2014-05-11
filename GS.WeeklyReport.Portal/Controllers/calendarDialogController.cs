using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class calendarDialogController : Controller
    {
        //
        // GET: /calendarDialog/
        public ActionResult calendarDialog()
        {
            return PartialView("~/Views/Shared/_CalendarDialogViewPage.cshtml");
        }
	}
}