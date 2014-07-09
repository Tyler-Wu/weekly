using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Service;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Ast.Selectors;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/
        public ActionResult Index()
        {
            //AddRole();
            //AddUser();
            AddProject();
            return View();
        }

        public ActionResult Add()
        {
            AddRole();
            //AddUser();
            AddProject();
            return Content("Test Content", "text/html");
        }

        private void AddProject()
        {
            IProjectService service = new ProjectService();
            IUserService userService = new UserService();
            //User user = userService.LoadEntities(u => u.UserName == "green").FirstOrDefault();
            List<User> users = new List<User>()
            {
                 new User()
                {
                    UserId =new Guid("75114361-8F65-6B0E-9A49-D281FC453B36"),
                    Name = "mike",
                    RoleId = 1,
                    CreateDate = DateTime.Now,
                    Password = "123456",
                    UserName = "mike"
                }
            };

            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    ProjectId = new Guid("3D6AB0EE-1D4D-A681-2D6C-9FBA28245E2C"),
                    Name = "parabola",
                    LeaderId = new Guid("2FEFF1B0-B86D-A711-37DD-A45210A53F56"),
                    Description = "1111",
                    Status = "1",
                    Color = "red",
                    StartDate = DateTime.Now,
                    User = users
                }
            };
            foreach (var project in projects)
            {
                service.Add(project);
            }
        }
        private void AddUser()
        {
            IUserService userService = new UserService();
            List<User> users = new List<User>()
            {
                new User()
                {
                    UserId =new Guid("2FEFF1B0-B86D-A711-37DD-A45210A53F56"),
                    Name = "tony",
                    RoleId = 1,
                    CreateDate = DateTime.Now,
                    Password = "123456",
                    UserName = "tony"
                },
                      new User()
                {
                    UserId =new Guid("DE395BA2-E458-06E4-180F-489B867014AE"),
                    Name = "green",
                    RoleId = 2,
                    CreateDate = DateTime.Now,
                    Password = "123456",
                    UserName = "green"
                }
            };
            foreach (var user in users)
            {
                userService.Add(user);
            }
        }

        private static void AddRole()
        {
            IRoleService role = new RoleService();
            List<Role> roles = new List<Role>()
            {
                new Role() {Name = "Admin"},
                new Role() {Name = "PM"},
                new Role() {Name = "Member"}
            };
            foreach (var item in roles)
            {
                role.Add(item);
            }
        }
    }
}