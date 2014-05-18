using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Service;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class ReportController : BaseController
    {
        IProjectService projectService=new ProjectService();
        //
        // GET: /Report/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InitChartInfo()
        {
            var categories = projectService.LoadEntities(p => true).Select(p=>new {p.Name,p.ProjectId});
            return Json("11");
        }
	}
}