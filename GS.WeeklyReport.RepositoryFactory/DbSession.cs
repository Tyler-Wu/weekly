using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class DbSession:IDbSession
    {
        private IWorkItemRepository _IWorkItemRepository;

        public IUserReposity UserReposity { get; private set; }
        public IProjectRepository ProjectRepository { get; private set; }

        public IWorkItemRepository WorkItemRepository
        {
            get { return _IWorkItemRepository ?? (_IWorkItemRepository = SimpelRepositorylFactory.GetUserinfoDal()); }
        }

        public int SaveChanges()
        {
            return DbSessionFactory.GetCurrentDbSession().SaveChanges();
        }
    }
}
