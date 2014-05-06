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

    public class RoleService : IRoleRepository
    {
        private IDbSession _dbSession = DbSessionFactory.GetCurrentDbSession();
        private IRoleRepository repository;

        public RoleService()
        {
            repository = _dbSession.RoleRepository;
        }

        public Role Add(Role entity)
        {
            return repository.Add(entity);
        }

        public bool Update(Role entity)
        {
            return repository.Update(entity);
        }

        public bool Delete(Role entity)
        {
            return repository.Delete(entity);
        }

        public IQueryable<Role> LoadEntities(Expression<Func<Role, bool>> whereLambda)
        {
            return repository.LoadEntities(whereLambda);
        }

        public IQueryable<Role> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, Expression<Func<Role, bool>> whereLambda, bool isAsc,
            Expression<Func<Role, S>> orderBy)
        {
            return repository.LoadPageEntities(pageSize, pageIndex, out totalCount, whereLambda, isAsc, orderBy);
        }
    }
}
