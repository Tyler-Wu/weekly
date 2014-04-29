using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
    public class UserService : IBaseRepositroy<User>
    {
        UserReposity reposity = new UserReposity();
        public User Add(User entity)
        {
            return reposity.Add(entity);
        }

        public bool Update(User entity)
        {
            return reposity.Update(entity);
        }

        public bool Delete(User entity)
        {
            return reposity.Delete(entity);
        }

        public IQueryable<User> LoadEntities(Expression<Func<User, bool>> whereLambda)
        {
            return reposity.LoadEntities(whereLambda);
        }

        public IQueryable<User> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, Expression<Func<User, bool>> whereLambda, bool isAsc,
            Expression<Func<User, S>> orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
