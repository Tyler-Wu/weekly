//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcWeeklyReport.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.WorkItem = new HashSet<WorkItem>();
        }
    
        public System.Guid PorjectId { get; set; }
        public string Name { get; set; }
        public System.Guid LeaderId { get; set; }
        public Nullable<System.DateTime> StartData { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<WorkItem> WorkItem { get; set; }
    }
}
