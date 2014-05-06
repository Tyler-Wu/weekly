using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.WeeklyReport.IRepository
{
    public interface IDbSession
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }

        IWorkItemRepository WorkItemRepository { get; }

        IRoleRepository RoleRepository { get; }
        int SaveChanges();
    }

}
