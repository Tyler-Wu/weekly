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

        public bool SaveProject(Project model, string ids)
        {
            if (model.ProjectId == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                model.ProjectId = Guid.NewGuid();
                model = projectRepository.Add(model);
            }
            model.User = userRepository.GetEntitiesByIds(ids);
            return projectRepository.Update(model);
        }
    }
}
