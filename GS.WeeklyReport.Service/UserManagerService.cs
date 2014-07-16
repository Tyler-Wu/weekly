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
        public bool SaveUser(User model, string ids, string editType)
        {
            User user; 
            List<Project> pro = string.IsNullOrEmpty(ids) ? null : projectRepository.GetEntitiesByIds(ids);
            if (editType == "add")
            {
                model.UserId = Guid.NewGuid();
                model = userRepository.Add(model);
                user = new User();
                user.Name = model.Name;
                user.RoleId = model.RoleId;
                user.UpdateDate = model.UpdateDate;
                user.UserId = model.UserId;
                user.CreateDate = model.CreateDate;
                user.UserName = model.UserName;
            }
            else
            {
             user = userRepository.LoadEntities(u => u.UserId == model.UserId).FirstOrDefault();
            }
            Project p;
            user.Project.Clear();
            if (pro!=null)
            {
                 for (int i = 0; i < pro.Count; i++)
                    {
                        user.Project.Add(pro[i]);
                    }
            }
            return userRepository.Update(user);
        }
     
    }
}
