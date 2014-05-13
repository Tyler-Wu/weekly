using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Repository
{
    public class BaseRepository<T> where T : class, new()
    {
        private DbContext db = DbContextFactory.GetCurrentDbContext();

        #region CUD

        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;

        }

        public bool Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        #endregion

        #region Query

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }


        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex,
            out int totalCount,
            Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderBy)
        {
            IQueryable<T> temp = db.Set<T>().Where(whereLambda).AsQueryable();

            totalCount = temp.Count();

            if (isAsc)
            {
                temp = temp.OrderBy(orderBy)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending(orderBy)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }

            return temp;
        }

        #endregion
    }
}
