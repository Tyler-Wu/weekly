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
                service.Add(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
                user.UpdateDate = entity.UpdateDate;
                // TODO: Add update logic here
                service.Update(user);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(Guid id)
        {
            var user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            return View(user);
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
                return View();
            }
        }
    }
}
