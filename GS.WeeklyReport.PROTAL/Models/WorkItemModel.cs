using System.Web.Util;

namespace GS.WeeklyReport.PROTAL.Models
{
    public class WorkItemModel : WorkItem
    {

        public string ProjectName { get; set; }
        public string Color { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
    }
}