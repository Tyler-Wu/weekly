using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.Service;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class ProjectController : BaseController
    {
        ProjectService service=new ProjectService();
        //
        // GET: /Project/
        public ActionResult Index()
        {
            var projectList=service.LoadEntities(p => true);
            return View(projectList);
        }
	}
}