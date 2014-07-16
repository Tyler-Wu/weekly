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
            var users = service.LoadEntities(u => true);
            foreach (var user in users)
            {
                usersList.Add(new UserViewModels()
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    RoleId = user.RoleId,
                    CreateDate = user.CreateDate,
                    UpdateDate = user.UpdateDate,
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
            }
           
            return ids.Length > 0 ? ids.Substring(0, ids.Length) : ids;
        }

        public JsonResult GetUserForSelect()
        {
            var users = service.LoadEntities(u => true).Select(u => new { text = u.UserName, value = u.UserId });
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult EditSaveProject(UserViewModels model)
        {
            var editType = Request["saveType"];

            User user = new User();
            user.Name = model.Name;
            user.RoleId = model.RoleId;
            user.UserName = model.UserName;
            user.CreateDate = model.CreateDate;
            user.UpdateDate = model.UpdateDate;
            user.UserId = model.UserId;
            userManagerService.SaveUser(user, model.Projects, editType);
            return null;
        }

        public JsonResult GetRoleselect()
        {
           var role=Roleservice.LoadEntities(r => true).Select(r=>new {text=r.RoleId,value=r.Name});
            return Json(role, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateUser(UserViewModels model)
        {
            var createType = Request["saveType"];
            User user = new User();
            user.Name = model.Name;
            user.RoleId = model.RoleId;
            user.UserName = model.UserName;
            user.CreateDate = model.CreateDate;
            user.UpdateDate = model.UpdateDate;
            userManagerService.SaveUser(user, model.Projects,createType);
            return null;
        }

        // GET: /User/Details/5
        public ActionResult Details(Guid id)
        {
            var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }

        //
        // GET: /User/Create
        //public ActionResult Create()
        //{

        //    return View();
        //}

        //
        // POST: /User/Create
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

        //
        // GET: /User/Edit/5
        public ActionResult Edit(Guid id)
        {
            var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(User entity)
        {
            try
            {
                User user = service.LoadEntities(u => u.UserId == entity.UserId).FirstOrDefault();
                user.Name = entity.Name;
                user.RoleId = entity.RoleId;
                user.UpdateDate = DateTime.Now;

                // TODO: Add update logic here
                service.Update(user);
                ViewBag.text = "You have edited the User successfully.";
                return View("success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("Error");
            }
        }

        //
        // GET: /User/Delete/5
        public String Delete(Guid id)
        {
            var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            if (service.Delete(user))
            {
                return "success";
            }
            else
            {
                return "false";
            }
        }

        //
        // POST: /User/Delete/5
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
