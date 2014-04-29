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
    public class WorkItemService
    {
        //private DbSession _dbSession = DbSessionFactory.GetCurrentDbSession();
        //private IWorkItemRepository _repository;

        //public WorkItemService()
        //{
        //    _repository = _dbSession.WorkItemRepository;
        //}

        WorkItemRepository _repository = new WorkItemRepository();
        public WorkItem Add(WorkItem workItem)
        {
            return _repository.Add(workItem);
        }
    }
}
