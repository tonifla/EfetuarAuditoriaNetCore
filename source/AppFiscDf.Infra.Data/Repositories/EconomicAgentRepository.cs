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
    public class EconomicAgentRepository : Repository<EconomicAgent>, IEconomicAgentRepository
    {
        private readonly SqlContext _context;

        public EconomicAgentRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EconomicAgent>> GetListAsync()
        {
            return await _context.EconomicAgent
                         .OrderBy(p => p.Company)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<EconomicAgent>> GetListByEconomicAgentAsync(string installationCnpj, string company)
        {
            return await _context.EconomicAgent
                         .Where(p => p.InstallationCnpj == installationCnpj
                                     || p.Company.ToUpper().Contains(string.IsNullOrEmpty(company) ? company : company.ToUpper()))
                         .OrderBy(p => p.Company)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}