using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var loginUser = Session["loginUser"] as User;
            if (loginUser == null)
            {
                Response.Redirect("/Login/Index");
            }
        }

	}
}