﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GS.WeeklyReport.IRepository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class SimpelRepositorylFactory
    {
        public static IWorkItemRepository GetWorkItemRepository()
        {
            string className = ConfigurationManager.AppSettings["DALNameScape"] + ".IWorkItemRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["DalAssembly"], className);
            return obj as IWorkItemRepository;
        }
        public static IUserRepository GetUserRepository()
        {
            //string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".IUserRepository";
            //object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".IUserRepository";
            object obj = Assembly.Load(ConfigurationManager.AppSettings["RepositoryAssembly"])
                .CreateInstance(className, true);
            return obj as IUserRepository;
        }

        public static IProjectRepository GetProjectRepository()
        {
            string className = ConfigurationManager.AppSettings["RepositoryNameScape"] + ".IProjectRepository";
            object obj = GetInstane(ConfigurationManager.AppSettings["RepositoryAssembly"], className);
            return obj as IProjectRepository;
        }

        public static object GetInstane(string assembly, string className)
        {
            object obj = HttpRuntime.Cache[assembly + className];
            if (obj == null)
            {
                obj = Assembly.Load(ConfigurationManager.AppSettings[assembly]).CreateInstance(className, true);
                HttpRuntime.Cache[assembly + className] = obj;
            }

            return obj;
        }
    }
}
