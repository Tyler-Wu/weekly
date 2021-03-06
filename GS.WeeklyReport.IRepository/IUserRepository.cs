﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyReport.Models;

namespace GS.WeeklyReport.IRepository
{
    public interface IUserRepository : IBaseRepositroy<User>
    {

        List<User> GetEntitiesByIds(string ids);
    }
}
