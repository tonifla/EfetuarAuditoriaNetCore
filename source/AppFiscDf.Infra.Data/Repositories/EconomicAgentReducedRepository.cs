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
    public class EconomicAgentReducedRepository : Repository<EconomicAgentReduced>, IEconomicAgentReducedRepository
    {
        private readonly SqlContext _context;

        public EconomicAgentReducedRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EconomicAgentReduced>> GetListAsync()
        {
            return await _context.EconomicAgentReduced
                         .OrderBy(p => p.Company)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<EconomicAgentReduced>> GetListByEconomicAgentReducedAsync(string installationCnpj, string company)
        {
            return await _context.EconomicAgentReduced
                         .Where(p => p.InstallationCnpj == installationCnpj
                                  || p.Company.ToUpper().Contains(string.IsNullOrEmpty(company) ? company : company.ToUpper()))
                         .OrderBy(p => p.Company)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}