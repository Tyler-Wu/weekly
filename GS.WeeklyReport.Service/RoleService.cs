using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.Repository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{

    public class RoleService
    {
         RoleRepository _repository = new RoleRepository();

        public Role Add(Role rold)
        {
            return _repository.Add(rold);
        }
    }
}
