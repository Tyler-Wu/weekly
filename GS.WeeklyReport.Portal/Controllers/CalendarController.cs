using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Portal.Models;
using GS.WeeklyReport.Service;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class CalendarController : BaseController
    {
        IWorkItemService workItemService=new WorkItemService();
        //IProjectService projectService=new ProjectService();
        //
        // GET: /Calendar/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CalendarDialog()
        {
            return View();
        }
        [HttpPost]
        public string AddWorkItem(WorkItemModel workItem)
        {
            return "success";
        }
       
	}
}