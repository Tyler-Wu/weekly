using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Portal.Models;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class ProjectController : BaseController
    {
        private IProjectService service = new ProjectService();
        private IUserService userService = new UserService();
        private ProjectManagerService projectManagerService = new ProjectManagerService();

        //
        // GET: /Project/
        public ActionResult Index()
        {
            var projectList = service.LoadEntities(p => true);
            return View(projectList);
            //return View();
        }

        [HttpGet]
        public JsonResult GetProject()
        {
            var projectList = new List<ProjectViewModel>();
            var projects = service.LoadEntities(p => true);
            //var projectList =
            //    project.Select(x => new { x.Name, x.LeaderId, x.StartDate, x.Description, x.Status, x.Color, x.User })
            //        .AsEnumerable();
            foreach (var project in projects)
            {
                projectList.Add(new ProjectViewModel()
                {
                    Name = project.Name,
                    LeaderId = project.LeaderId,
                    StartDate = project.StartDate,
                    Description = project.Description,
                    Status = project.Status,
                    Color = project.Color,
                    Members = GetUserIds(project.User)
                });
            }
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjiectForSelect()
        {
            var project = service.LoadEntities(p => true).Select(c => new { value = c.ProjectId, text = c.Name });
            return Json(project, JsonRequestBehavior.AllowGet);
        }

        private string GetUserIds(ICollection<User> users)
        {
            string ids = "";
            if (users.Count > 0)
            {
                ids = users.Aggregate(ids, (current, user) => current + (user.UserId + ","));
            }
            return ids.Length > 0 ? ids.Substring(0, ids.Length) : ids;
        }

        [HttpPost]
        public ActionResult SaveProject(ProjectViewModel model)
        {
            var project = new Project()
            {
                ProjectId = model.ProjectId,
                Name = model.Name,
                LeaderId = model.LeaderId,
                StartDate = DateTime.Now,
                Color = model.Color,
                Status = "1",
                Description = model.Description
            };
            projectManagerService.SaveProject(project, model.Members);

            return Content("111");
        }
    }
}