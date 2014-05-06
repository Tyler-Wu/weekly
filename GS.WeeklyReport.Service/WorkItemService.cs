using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.RepositoryFactory;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
    public class WorkItemService : IWorkItemRepository
    {
        private DbSession _dbSession = DbSessionFactory.GetCurrentDbSession();
        private IWorkItemRepository _repository;

        public WorkItemService()
        {
            _repository = _dbSession.WorkItemRepository;
        }


        public WorkItem Add(WorkItem entity)
        {
            return _repository.Add(entity);
        }


        public bool Update(WorkItem entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(WorkItem entity)
        {
            return _repository.Delete(entity);
        }

        public IQueryable<WorkItem> LoadEntities(System.Linq.Expressions.Expression<Func<WorkItem, bool>> whereLambda)
        {
            return _repository.LoadEntities(whereLambda);
        }

        public IQueryable<WorkItem> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, System.Linq.Expressions.Expression<Func<WorkItem, bool>> whereLambda, bool isAsc, System.Linq.Expressions.Expression<Func<WorkItem, S>> orderBy)
        {
            return _repository.LoadPageEntities(pageSize, pageIndex, out totalCount, whereLambda, isAsc, orderBy);
        }
    }
}
