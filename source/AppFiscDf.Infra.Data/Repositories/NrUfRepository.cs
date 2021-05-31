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
    public class NrUfRepository : Repository<NrUf>, INrUfRepository
    {
        private readonly SqlContext _context;

        public NrUfRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NrUf>> GetListAsync()
        {
            return await _context.NrUf
                         .Include(u => u.UfList)
                         .OrderBy(p => p.Acronym)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}