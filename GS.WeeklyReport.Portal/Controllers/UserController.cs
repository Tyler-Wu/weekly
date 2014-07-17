using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;
using GS.WeeklyReport.Portal.Models;


namespace GS.WeeklyReport.Portal.Controllers
{
    public class UserController : BaseController
    {
        IUserService service = new UserService();
        IRoleService Roleservice=new RoleService();
        private UserManagerService userManagerService = new UserManagerService();
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUsers()
        {
            var usersList = new List<UserViewModels>();
            var users = userManagerService.LoadEntities(u => true);
            foreach (var user in users)
            {
                usersList.Add(new UserViewModels()
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    RoleId = user.RoleId,
                    CreateDate = user.CreateDate,
                    UpdateDate =user.UpdateDate,
                    Projects = GetProjectIds(user.Project),
                    UserId = user.UserId,
                });
            }
            return Json(usersList, JsonRequestBehavior.AllowGet);
        }
        private string GetProjectIds(ICollection<Project> pro)
        {
            string ids = "";
            if (pro!=null)
            {
                 if (pro.Count > 0)
                {
                    ids = pro.Aggregate(ids, (current, user) => current + (user.ProjectId + ","));

                }
                if (ids != "")
                {
                    ids = ids.Remove(ids.Length - 1);
                }
            }
           
            return ids.Length > 0 ? ids.Substring(0, ids.Length) : ids;
        }

        public JsonResult GetUserForSelect()
        {
            var users = service.LoadEntities(u => true).Select(u => new { text = u.UserName, value = u.UserId });
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUser(UserViewModels model)
        {
            var editType = Request["saveType"];

            User user = new User();
            user.Name = model.Name;
            user.RoleId = model.RoleId;
            user.UserName = model.UserName;
            user.CreateDate = model.CreateDate;
            user.UpdateDate = model.UpdateDate;
            user.UserId = model.UserId;
            user = userManagerService.SaveUser(user, model.Projects, editType);
            if (user != null)
            {
                return Json(new { user.CreateDate, user.UpdateDate }, JsonRequestBehavior.AllowGet);
            }
            return Json("fail", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoleselect()
        {
            var role = Roleservice.LoadEntities(r => true).Select(r => new { value = r.RoleId, text = r.Name });
            return Json(role, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(User entity)
        {
            try
            {
                // TODO: Add insert logic here
                entity.UserId = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                service.Add(entity);
                return View("success");
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
                service.Delete(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

    }
}
