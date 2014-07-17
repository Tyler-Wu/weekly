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
        private ProjectManagerService projectManagerService = new ProjectManagerService();

        //
        // GET: /Project/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProject()
        {
            var projectList = new List<ProjectViewModel>();
            var projects =projectManagerService.LoadEntities(p=>true);
            foreach (var project in projects)
            {
                projectList.Add(new ProjectViewModel()
                {
                    ProjectId = project.ProjectId,
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
            if (users != null)
            {
                if (users.Count > 0)
                {
                    ids = users.Aggregate(ids, (current, user) => current + (user.UserId + ","));
                    
                }
                ids = ids.Remove(ids.Length - 1);
            }
            return ids.Length > 0 ? ids.Substring(0, ids.Length) : ids;
        }

        [HttpPost]
        public ActionResult SaveProject(ProjectViewModel model)
        {
            var saveType = Request["saveType"];
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
            projectManagerService.SaveProject(project, model.Members, saveType);

            return Content("111");
        }
    }
}