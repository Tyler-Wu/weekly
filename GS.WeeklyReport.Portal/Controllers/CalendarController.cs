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
        private IUserService userService = new UserService();
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
        public JsonResult GetWorkItemList()
        {
            _loginUser = Session["loginUser"] as User;
            var workItemList = workItemService.LoadEntities(w => w.UserId == _loginUser.UserId).Select(item=>new
            {
                workItemId=item.ItemId,
                id=item.ItemId,
                title=item.Project.Name,
                start=item.Start,
                end=item.End,
                allDay=item.AllDay,
                color=item.Project.Color,
                projectId=item.Project.ProjectId
            }).AsEnumerable();
            return Json(workItemList, JsonRequestBehavior.AllowGet);
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
        public String AddWorkItem(WorkItem workItem)
        {
            _loginUser = Session["loginUser"] as User;
            //
            if (_loginUser != null)
            {
                    workItem.ItemId = Guid.NewGuid();
                    workItem.UserId = _loginUser.UserId;
                    workItem.CreateUser = _loginUser.UserId;
                    workItem.CreateDate = DateTime.Now;
                    workItem.StartDate = TimeHelper.GetTime(workItem.Start.ToString());
                    workItem.EndDate = TimeHelper.GetTime(workItem.End.ToString());
                    workItem.ProjectId = workItem.ProjectId;
                    workItem.Project = projectService.LoadEntities(p => p.ProjectId == workItem.ProjectId).FirstOrDefault();
                    var model = workItemService.Add(workItem);
                    if (model != null)
                    {
                        return model.ItemId.ToString();
                    }
            }
            return "fail";
        }

        [HttpPost]
        public String UpdateWorkItem(WorkItem workItem)
        {
            _loginUser = Session["loginUser"] as User;
            //
            if (_loginUser != null)
            {
                WorkItem oldItem = workItemService.LoadEntities(w => w.ItemId == workItem.ItemId).FirstOrDefault();
                oldItem.UpdateUser = _loginUser.UserId;
                oldItem.Duration = workItem.Duration;
                oldItem.UpdateDate = DateTime.Now;
                oldItem.Start = workItem.Start;
                oldItem.End = workItem.End;
                oldItem.StartDate = TimeHelper.GetTime(workItem.Start.ToString());
                oldItem.EndDate = TimeHelper.GetTime(workItem.End.ToString());
                oldItem.Body = workItem.Body;
                if (workItemService.Update(oldItem))
                {
                    return "success";
                }
            }
            return "fail";
        }

        public String DelWorkItem(WorkItem workItem)
        {
            _loginUser = Session["loginUser"] as User;
            if (_loginUser != null)
            {
                WorkItem oldItem=workItemService.LoadEntities(w => w.ItemId == workItem.ItemId).FirstOrDefault();
                if (workItemService.Delete(oldItem))
                {
                    return "success";
                }
            }
            return "fail";
        }
    }
}