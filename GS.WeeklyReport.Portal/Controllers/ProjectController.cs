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
        IProjectService service=new ProjectService();
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
          var Project=  service.LoadEntities(p => true);
          foreach (var item in Project)
          {
              
          }
          var Projectlis = Project.Select(x => new { Name = x.Name, UName = x.User.Name, StartDate =x.StartDate, Description = x.Description, Status = x.Status, Color = x.Color}).AsEnumerable();
          return Json(Projectlis, JsonRequestBehavior.AllowGet);
        }

  
	}
}