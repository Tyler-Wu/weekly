using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class SimpelRepositorylFactory
    {
        public static IWorkItemRepository GetWorkItemRepository()
        {
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".WorkItemRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            return obj as IWorkItemRepository;
        }
        public static IUserRepository GetUserRepository()
        {
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".UserRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            return obj as IUserRepository;
        }

        public static IProjectRepository GetProjectRepository()
        {
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".ProjectRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            return obj as IProjectRepository;

        }
        internal static IRoleRepository GetRoleRepository()
        {
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".RoleRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            return obj as IRoleRepository;
        }

        public static object GetInstane(string assembly, string className)
        {
            object obj = HttpRuntime.Cache[assembly + className];
            if (obj == null)
            {
                obj = Assembly.Load(assembly).CreateInstance(className, true);
                HttpRuntime.Cache[assembly + className] = obj;
            }

            return obj;
        }
    }
}
