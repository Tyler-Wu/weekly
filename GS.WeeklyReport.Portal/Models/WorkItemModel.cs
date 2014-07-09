using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Models
{
    public class WorkItemModel : WorkItem
    {

        public string ProjectName { get; set; }
        public string Color { get; set; }
        public long Start { get; set; } 
        public long End { get; set; }

    }
}