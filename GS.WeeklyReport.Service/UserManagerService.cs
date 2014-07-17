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
        public bool SaveUser(User model, string ids, string editType)
        {
            User user; 
            List<Project> pro = string.IsNullOrEmpty(ids) ? null : projectRepository.GetEntitiesByIds(ids);
            if (editType == "add")
            {
                model.UserId = Guid.NewGuid();
                user = new User();
                user.Name = model.Name;
                user.RoleId = model.RoleId;
                user.UpdateDate = System.DateTime.Now;
                user.UserId = model.UserId;
                user.CreateDate = System.DateTime.Now;
                user.UserName = model.UserName; 
                user = userRepository.Add(user);
            }
            else
            {
             user = userRepository.LoadEntities(u => u.UserId == model.UserId).FirstOrDefault();
                user.UpdateDate = System.DateTime.Now;
            }
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

        public IQueryable<User> LoadEntities(Expression<Func<User, bool>> whereExpression)
        {
            return userRepository.LoadEntities(whereExpression);
        }
    }
}
