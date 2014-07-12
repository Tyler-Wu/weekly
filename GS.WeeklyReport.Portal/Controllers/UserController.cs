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
    public class UserController : BaseController
    {
        IUserService service = new UserService();
        //
        // GET: /User/
        public ActionResult Index()
        {
            var users = service.LoadEntities(u => true);
            return View(users);
        }

        public JsonResult GetUserForSelect()
        {
            var users = service.LoadEntities(u => true).Select(u => new { text=u.UserName, value=u.UserId });
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /User/Details/5
        public ActionResult Details(Guid id)
        {
            var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {

            return View();
        }

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
