﻿using System;
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
        public ActionResult CalendarDialog(string endTime,string startTime,String title,String color)
        { 
            IProjectService service =new ProjectService();
            var list=service.LoadEntities(p => true).Select(i=>new {i.Name,i.ProjectId}).AsEnumerable();
            ViewBag.ProjectList = list;
            ViewBag.EndTime = endTime;
            ViewBag.StartTime = startTime;
            ViewBag.ProjectTitle = title;
            ViewBag.Color = color;
            return PartialView("~/Views/Shared/_CalendarDialogViewPage.cshtml");
        }
	}
}