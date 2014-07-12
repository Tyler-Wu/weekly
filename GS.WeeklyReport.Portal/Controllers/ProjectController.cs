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
            var project = service.LoadEntities(p => true);
            var projectList =
                project.Select(x => new { x.Name, x.LeaderId, x.StartDate, x.Description, x.Status, x.Color, x.User })
                    .AsEnumerable();
            return Json(projectList, JsonRequestBehavior.AllowGet);
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