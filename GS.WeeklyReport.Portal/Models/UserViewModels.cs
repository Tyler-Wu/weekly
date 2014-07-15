using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.WeeklyReport.Portal.Models
{
    public class UserViewModels
    {
        public System.Guid UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Projects { get; set; }
    }
}