using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;

namespace GS.WeeklyReport.RepositoryFactory
{
    public class DbSession : IDbSession
    {
        private IWorkItemRepository _workItemRepository;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private IRoleRepository _roleRepository;

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = SimpelRepositorylFactory.GetUserRepository()); }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                return _projectRepository ?? (_projectRepository = SimpelRepositorylFactory.GetProjectRepository());
            }
        }

        public IWorkItemRepository WorkItemRepository
        {
            get { return _workItemRepository ?? (_workItemRepository = SimpelRepositorylFactory.GetWorkItemRepository()); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = SimpelRepositorylFactory.GetRoleRepository()); }
        }

        public int SaveChanges()
        {
            return DbSessionFactory.GetCurrentDbSession().SaveChanges();
        }
    }
}
