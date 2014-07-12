using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.WeeklyReport.IRepository;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public List<User> GetEntitiesByIds(string ids)
        {
            var arry = ids.Split(',');
            return arry.Select(item => new Guid(item)).Select(id => LoadEntities(u => u.UserId == id).SingleOrDefault()).ToList();
        }
    }
}
