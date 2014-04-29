using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class DbSession
    {
        private IWorkItemRepository _IWorkItemRepository;
        public IWorkItemRepository WorkItemRepository
        {
            get { return _IWorkItemRepository ?? (_IWorkItemRepository = SimpelRepositorylFactory.GetUserinfoDal()); }
        }
    }
}
