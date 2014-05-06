
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.RepositoryFactory;

namespace GS.WeeklyReport.Service
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IDbSession DbSession = DbSessionFactory.GetCurrentDbSession();
        public IBaseRepositroy<T> CurrentRepositroy;

        public BaseService()
        {
            SetCurrentRepositroy();
        }

        public abstract void SetCurrentRepositroy();

        public T Add(T entity)
        {
            CurrentRepositroy.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentRepositroy.Update(entity);
           return  DbSession.SaveChanges()>0;
           
        }

        public bool Delete(T entity)
        {
            CurrentRepositroy.Delete(entity);
           return  DbSession.SaveChanges() > 0;

        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepositroy.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex,
            out int totalCount,
            Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderBy)
        {
            return CurrentRepositroy.LoadPageEntities(pageSize, pageIndex, out totalCount, whereLambda, isAsc, orderBy);
        }
    }
}
