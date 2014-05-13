﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Portal.Models;
using GS.WeeklyReport.Service;
using GS.WeeklyReport.Common;
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
            var projectList = projectService.LoadEntities(p => true).AsEnumerable();
            ViewBag.projectList = projectList;
            return View();
        }

        public ActionResult CalendarDialog()
        {
            return View();
        }

        [HttpPost]
        public string AddWorkItem(WorkItem workItem)
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

                    workItem.ProjectId = new Guid("0478EB82-E075-4811-B6AB-2BF85CC96000");
                    workItemService.Add(workItem);
                }
                else
                {
                    workItem.UpdateDate = DateTime.Now;
                    workItem.UpdateUser = _loginUser.UserId;
                    workItemService.Update(workItem);
                }
            }
            return "success";
        }
    }
}