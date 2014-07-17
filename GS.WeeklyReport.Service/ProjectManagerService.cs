using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public bool SaveProject(Project model, string members, string saveType)
        {
            Project project;
            List<User> user = string.IsNullOrEmpty(members) ? null : userRepository.GetEntitiesByIds(members);
            if (saveType == "add")
            {
                model.ProjectId = Guid.NewGuid();
               
                project = projectRepository.Add(model);
            }
            else
            {
                project = projectRepository.LoadEntities(p => p.ProjectId == model.ProjectId).SingleOrDefault();
                project.Color = model.Color;
                project.LeaderId = model.LeaderId;
                project.Description = model.Description;
                project.Status = model.Status;
                project.StartDate = model.StartDate;
            }
            project.User.Clear();
            project.User = user;
           return projectRepository.Update(project);
        }
        public IQueryable<Project> LoadEntities(Expression<Func<Project, bool>> whereExpression)
        {
            return projectRepository.LoadEntities(whereExpression);
        }
    }
}
