using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.RepositoryFactory;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
    public class UserService : IBaseRepositroy<User>
    {
        private IDbSession _dbSession = DbSessionFactory.GetCurrentDbSession();
        private IUserRepository repository;

        public UserService()
        {
            repository = _dbSession.UserRepository;
        }
        //UserRepository repository = new UserRepository();
        public User Add(User entity)
        {
            return repository.Add(entity);
        }

        public bool Update(User entity)
        {
            return repository.Update(entity);
        }

        public bool Delete(User entity)
        {
            return repository.Delete(entity);
        }

        public IQueryable<User> LoadEntities(Expression<Func<User, bool>> whereLambda)
        {
            return repository.LoadEntities(whereLambda);
        }

        public IQueryable<User> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, Expression<Func<User, bool>> whereLambda, bool isAsc,
            Expression<Func<User, S>> orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
