using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeeklyReport.Models;

namespace MvcWeeklyReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            Entities context = new Entities();
            var user = new User();
            user.CreateDate = DateTime.Now;
            user.Name = "Hello";
            user.UserId = Guid.NewGuid();
            user.UpdateData = DateTime.Now;
            context.User.Add(user);
            context.SaveChanges();
            //WeeklyReportEntities a = new WeeklyReportEntities();
            //User user=new User();
            //user.CreateDate = DateTime.Now;

            //a.User.Add(user);

            //a.SaveChanges();

            //ViewBag.Data = from p in a.User select p;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
