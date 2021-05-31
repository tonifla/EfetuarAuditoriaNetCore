using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private readonly SqlContext _context;

        public ActivityRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetListAsync()
        {
            return await _context.Activity
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetListByActivityAsync(string name)
        {
            return await _context.Activity
                         .Where(p => p.Name.ToUpper().Contains(string.IsNullOrEmpty(name) ? name : name.ToUpper()))
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}