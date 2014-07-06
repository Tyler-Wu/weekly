using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Service;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class ProjectController : BaseController
    {
        IProjectService service = new ProjectService();
        IUserService userService = new UserService();

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
            var projectList = project.Select(x => new { x.Name, UName =x.Leader.Name, x.StartDate, x.Description, x.Status, x.Color, x.User}).AsEnumerable();
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }


    }
}