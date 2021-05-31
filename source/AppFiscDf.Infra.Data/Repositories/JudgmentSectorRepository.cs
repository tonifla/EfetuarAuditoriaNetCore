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
    public class JudgmentSectorRepository : Repository<JudgmentSector>, IJudgmentSectorRepository
    {
        private readonly SqlContext _context;

        public JudgmentSectorRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JudgmentSector>> GetListAsync()
        {
            return await _context.JudgmentSector
                         .OrderBy(p => p.Acronym)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}