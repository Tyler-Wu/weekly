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
        //
        // GET: /calendarDialog/
        public ActionResult CalendarDialog(string endTime, string startTime, String title, String backgroundColor, String id, String allDay, String workItemId, String duration,String calendarId)
        { 
            IProjectService service =new ProjectService();
            var list=service.LoadEntities(p => true).Select(i=>new {i.Name,i.ProjectId}).AsEnumerable();
            ViewData["calendarId"] = calendarId;
            ViewData["ProjectList"] = list;
            ViewData["EndTime"] = endTime;
            ViewData["StartTime"] = startTime;
            ViewData["ProjectTitle"] = title;
            ViewData["Color"] = backgroundColor;
            ViewData["Id"] = id;
            ViewData["allDay"] = allDay;
            ViewData["workItemId"] = workItemId;
            ViewData["duration"] = duration;
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