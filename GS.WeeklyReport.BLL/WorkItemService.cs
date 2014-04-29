using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.BLL
{
    public class WorkItemService
    {
        WorkItemRepository repository = new WorkItemRepository();

        public WorkItem Add(WorkItem entity)
        {
            return repository.Add(entity);
        }
    }
}
