using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{
    public class ProjectService : IProjectRepository
    {
        ProjectRepository repository = new ProjectRepository();

        public Project Add(Project entity)
        {
            return repository.Add(entity);
        }

        public bool Update(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Project entity)
        {
            throw new NotImplementedException();    
        }

        public IQueryable<Project> LoadEntities(Expression<Func<Project, bool>> whereLambda)
        {
            return repository.LoadEntities(whereLambda);
        }

        public IQueryable<Project> LoadPageEntities<S>(int pageSize, int pageIndex, out int totalCount, Expression<Func<Project, bool>> whereLambda, bool isAsc,
            Expression<Func<Project, S>> orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
