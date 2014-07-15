using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
    public class ProjectManagerService
    {
        private IUserRepository userRepository = new UserRepository();
        private IProjectRepository projectRepository = new ProjectRepository();

        public bool SaveProject(Project model, string members, string editType)
        {
            if (editType == "add")
            {
                model.ProjectId = Guid.NewGuid();
                model = projectRepository.Add(model);
            }

            model.User = string.IsNullOrEmpty(members) ? null : userRepository.GetEntitiesByIds(members);
            return projectRepository.Update(model);
        }
    }
}
