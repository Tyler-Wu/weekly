using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
  public  class UserManagerService
    {
        private IUserRepository userRepository = new UserRepository();
        private IProjectRepository projectRepository = new ProjectRepository();
        public User SaveUser(User model, string ids)
        {
           
            model.Project = projectRepository.GetEntitiesByIds(ids);
            return model;
            
            // return userRepository.Update(model);
        }
        public bool CreateUser(User model, string ids)
        {
           
                model.UserId = Guid.NewGuid();
                model = userRepository.Add(model);
            if (ids!=null)
            {
                model.Project = projectRepository.GetEntitiesByIds(ids);
            }
            return userRepository.Update(model);
        }
    }
}
