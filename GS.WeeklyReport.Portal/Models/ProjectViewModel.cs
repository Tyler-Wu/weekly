using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Models
{
    public class ProjectViewModel
    {
        public System.Guid ProjectId { get; set; }
        public string Name { get; set; }
        public System.Guid LeaderId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
        public DateTime? StartDate { get; set; }
        public string Members { get; set; }

    }
}