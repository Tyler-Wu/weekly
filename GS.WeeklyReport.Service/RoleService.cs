﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.RepositoryFactory;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Service
{

    public class RoleService : BaseService<Role>,IService.IRoleService
    {
        public override void SetCurrentRepositroy()
        {
            this.CurrentRepositroy = DbSession.RoleRepository;
        }
    }
}
