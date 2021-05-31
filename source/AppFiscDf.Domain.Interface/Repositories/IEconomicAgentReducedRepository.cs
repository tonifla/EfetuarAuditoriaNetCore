using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IEconomicAgentReducedRepository : IRepository<EconomicAgentReduced>
    {
        Task<IEnumerable<EconomicAgentReduced>> GetListAsync();

        Task<IEnumerable<EconomicAgentReduced>> GetListByEconomicAgentReducedAsync(string installationCnpj, string company);
    }
}