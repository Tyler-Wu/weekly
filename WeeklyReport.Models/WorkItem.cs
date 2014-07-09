//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeeklyReport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkItem
    {
        public System.Guid ItemId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid ProjectId { get; set; }
        public string Body { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.Guid> CreateUser { get; set; }
        public Nullable<System.Guid> UpdateUser { get; set; }
        public bool AllDay { get; set; }
        public double Duration { get; set; }
        public Nullable<long> End { get; set; }
        public Nullable<long> Start { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
