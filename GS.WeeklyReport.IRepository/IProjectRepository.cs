using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyReport.Models;

namespace GS.WeeklyReport.IRepository
{
    public interface IProjectRepository:IBaseRepositroy<Project>
    {
        List<Project> GetEntitiesByIds(string ids);
    }
}
