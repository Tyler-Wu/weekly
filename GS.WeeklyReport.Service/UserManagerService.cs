using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public User SaveUser(User model, string ids, string editType)
        {
            User user; 
           // List<Project> pro = string.IsNullOrEmpty(ids) ? null : projectRepository.GetEntitiesByIds(ids);
            if (editType == "add")
            {
                model.UserId = Guid.NewGuid();
                model.UpdateDate = System.DateTime.Now;
                model.CreateDate = System.DateTime.Now;
                user = userRepository.Add(model);
            }
            else
            {
             user = userRepository.LoadEntities(u => u.UserId == model.UserId).FirstOrDefault();
                user.UpdateDate = System.DateTime.Now;
                user.Name = model.Name;
                user.RoleId = model.RoleId;
                user.UserName = model.UserName;
            }
            user.Project.Clear();
            user.Project = string.IsNullOrEmpty(ids) ? null : projectRepository.GetEntitiesByIds(ids);
            if (userRepository.Update(user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<User> LoadEntities(Expression<Func<User, bool>> whereExpression)
        {
            return userRepository.LoadEntities(whereExpression);
        }
    }
}
