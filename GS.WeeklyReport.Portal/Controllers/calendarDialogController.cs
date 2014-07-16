using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class CalendarDialogController : Controller
    {
        IWorkItemService workItemService = new WorkItemService();
        //
        // GET: /calendarDialog/
        public ActionResult CalendarDialog(String backgroundColor, String id)
        {
            WorkItem workItem=workItemService.LoadEntities(w => w.ItemId == new Guid(id)).FirstOrDefault();
            ViewData["calendarId"] = workItem.ItemId;
            //ViewData["ProjectList"] = list;
            ViewData["body"] = workItem.Body??"";
            ViewData["EndTime"] = workItem.End;
            ViewData["StartTime"] = workItem.Start;
            ViewData["ProjectTitle"] = workItem.Project.Name;
            ViewData["Color"] =backgroundColor;
            ViewData["Id"] = workItem.ItemId;
            ViewData["allDay"] = workItem.AllDay;
            ViewData["workItemId"] = workItem.ItemId;
            ViewData["duration"] = workItem.Duration;
            //ViewBag.calendarId = calendarId;
            //ViewBag.ProjectList = list;
            //ViewBag.EndTime = endTime;
            //ViewBag.StartTime = startTime;
            //ViewBag.ProjectTitle = title;
            //ViewBag.Color = backgroundColor;
            //ViewBag.Id = id;
            //ViewBag.allDay = allDay;
            //ViewBag.workItemId = workItemId;
            //ViewBag.duration = duration;
            return PartialView("~/Views/Shared/_CalendarDialogViewPage.cshtml");
        }
	}
}