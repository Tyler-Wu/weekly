using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Portal.Models;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class CalendarController : BaseController
    {
        IWorkItemService workItemService = new WorkItemService();
        IProjectService projectService = new ProjectService();
        private User _loginUser;

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
            _loginUser = Session["loginUser"] as User;
            //
            if (workItem.ItemId == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                workItem.ItemId = Guid.NewGuid();
                if (_loginUser != null)
                {
                    workItem.User = _loginUser;
                    workItem.UserId = workItem.User.UserId;
                    workItem.CreateUser = workItem.User.UserId;
                }
                workItem.Project = projectService.LoadEntities(p => p.Name == "Default").FirstOrDefault();
             
                //workItem.ProjectId = new Guid("9a8dc7e3-247b-2757-1323-003b78b0d220");
                workItem.ProjectId = workItem.Project.PorjectId;
                workItem.StartDate = GetTime(workItem.Start.ToString());
                workItem.EndDate = GetTime(workItem.End.ToString());
                workItem.StartTime = new TimeSpan(workItem.Start);
                workItem.EndTime = new TimeSpan(workItem.End);
                workItem.CreateDate = DateTime.Now;
                var modelItem = new WorkItem()
                {
                    ItemId = workItem.ItemId,
                    CalendarId = workItem.CalendarId,
                    StartDate = workItem.StartDate,
                    EndDate = workItem.EndDate,
                    StartTime = workItem.StartTime,
                    Project = workItem.Project,
                    ProjectId = workItem.ProjectId,
                    CreateDate = workItem.CreateDate,
                    UserId = workItem.UserId,
                    User = workItem.User,
                    CreateUser = workItem.CreateUser,
                    Duration = workItem.Duration,
                    AllDay = workItem.AllDay
                };

                workItemService.Add(modelItem);

            }
            else
            {

            }
            return "success";
        }
        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

    }
}