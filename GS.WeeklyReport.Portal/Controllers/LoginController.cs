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
          
            return View();
        }

        public ActionResult Login(User loginUser)
        {
            if (!string.IsNullOrEmpty(loginUser.UserName) && !string.IsNullOrEmpty(loginUser.Passwrod))
            {
                var user = service.LoadEntities(u => u.UserName == loginUser.UserName && u.Passwrod == loginUser.Passwrod).FirstOrDefault();
                if (user != null)
                {
                    Session["loginUser"] = user;
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            return View("Index");
        }
    }
}