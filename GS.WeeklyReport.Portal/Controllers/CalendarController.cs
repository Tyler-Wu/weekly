using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Portal.Models;
using GS.WeeklyReport.Service;
using GS.WeeklyReport.Common;
using Microsoft.Ajax.Utilities;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class CalendarController : BaseController
    {
        private IWorkItemService workItemService = new WorkItemService();
        private IProjectService projectService = new ProjectService();
        private User _loginUser;

        // GET: /Calendar/
        public ActionResult Index()
        {
            //var projectList = projectService.LoadEntities(p => true).AsEnumerable();
            //ViewBag.projectList = projectList;
            return View();
        }

        public ActionResult CalendarDialog()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetProjectList()
        {
            var projectList = projectService.LoadEntities(p => true).Select(item => new { item.ProjectId, item.Name, item.Color }).AsEnumerable();
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetWorkItem(int timeSpan)
        {
            DateTime dt = DateTime.Now;
            DateTime start = new DateTime(dt.Year, dt.Month, 1);  //月初日期
            DateTime end = start.AddMonths(1).AddDays(-1);  //月底日期
            var workItemList = workItemService.LoadEntities(w => w.StartDate < start && w.EndDate > end).AsEnumerable();
            return Json(workItemList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddWorkItem(WorkItem workItem)
        {
            _loginUser = Session["loginUser"] as User;
            //
            if (_loginUser != null)
            {
                if (workItem.ItemId == new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    workItem.ItemId = Guid.NewGuid();
                    workItem.UserId = _loginUser.UserId;
                    workItem.CreateUser = _loginUser.UserId;
                    workItem.CreateDate = DateTime.Now;
                    workItem.StartDate = TimeHelper.GetTime(workItem.Start.ToString());
                    workItem.EndDate = TimeHelper.GetTime(workItem.End.ToString());
                    workItem.ProjectId = workItem.ItemId;
                    var model = workItemService.Add(workItem);
                    if (model != null)
                    {
                        return Content(model.ItemId.ToString());
                    }
                }
                else
                {
                    workItem.UpdateDate = DateTime.Now;
                    workItem.UpdateUser = _loginUser.UserId;
                    WorkItem oldItem = workItemService.LoadEntities(w => w.ItemId == workItem.ItemId).FirstOrDefault();
                    oldItem.Project = workItem.Project;
                    if (workItemService.Update(oldItem))
                    {
                        return Content("sucessful");
                    }
                }
            }
            return Content("fail");
        }
    }
}