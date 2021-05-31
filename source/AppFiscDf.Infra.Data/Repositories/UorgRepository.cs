using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class UorgRepository : Repository<Uorg>, IUorgRepository
    {
        private readonly SqlContext _context;

        public UorgRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Uorg> GetFindByUorgAsync(string acronym)
        {
            return await _context.Uorg
                         .Where(p => p.Acronym == (string.IsNullOrEmpty(acronym) ? acronym : acronym.ToUpper()))
                         .Include(i => i.InspectionProcedureList)
                         .ThenInclude(t => t.TypificationList)
                         .ThenInclude(a => a.Activity)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}