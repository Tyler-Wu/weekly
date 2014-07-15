using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Repository
{
    public class ProjectRepository:BaseRepository<Project>,IProjectRepository
    {
        public List<Project> GetEntitiesByIds(string ids)
        {
            var arry = ids.Split(',');
           
             List<Project> P=  arry.Select(item => new Guid(item)).Select(id => LoadEntities(u =>u.ProjectId== id).FirstOrDefault()).ToList();
            return P;
        }
    }
}
