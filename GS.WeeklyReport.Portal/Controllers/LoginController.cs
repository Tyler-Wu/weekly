using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class LoginController : Controller
    {

        UserService service = new UserService();
        //
        // GET: /Login/
       
        public ActionResult Index(User loginUser)
        {
            if (!string.IsNullOrEmpty(loginUser.UserName)&&!string.IsNullOrEmpty(loginUser.Passwrod))
            {
                return Login(loginUser.UserName, loginUser.Passwrod);
            }
           
            return View();
        }

          

        public ActionResult Login(string username, string password)
        {
            var user = service.LoadEntities(u => u.UserName == username && u.Passwrod == password).FirstOrDefault();
            if (user != null)
            {
                Session["loginUser"] = user;
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}