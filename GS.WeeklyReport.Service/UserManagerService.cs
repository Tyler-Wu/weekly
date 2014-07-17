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
    public class UserManagerService
    {

        private IUserRepository userRepository = new UserRepository();
        private IProjectRepository projectRepository = new ProjectRepository();
        public User SaveUser(User model, string ids, string editType)
        {
            User user;
            if (editType == "add")
            {
                model.UserId = Guid.NewGuid();
                model.UpdateDate = DateTime.Now;
                model.CreateDate = DateTime.Now;
                user = userRepository.Add(model);
            }
            else
            {
                user = userRepository.LoadEntities(u => u.UserId == model.UserId).FirstOrDefault();
                user.UpdateDate = DateTime.Now;
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
            return null;
        }

        public IQueryable<User> LoadEntities(Expression<Func<User, bool>> whereExpression)
        {
            return userRepository.LoadEntities(whereExpression);
        }
        public IQueryable<User> LoadPageEntities<TS>(int pageSize, int pageIndex,
           out int totalCount,
           Expression<Func<User, bool>> whereLambda, bool isAsc, Expression<Func<User, TS>> orderBy)
        {
            return userRepository.LoadPageEntities(pageSize, pageIndex, out totalCount, whereLambda, isAsc, orderBy);
        }
    }
}
