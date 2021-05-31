using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IEconomicAgentRepository : IRepository<EconomicAgent>
    {
        Task<IEnumerable<EconomicAgent>> GetListAsync();

        Task<IEnumerable<EconomicAgent>> GetListByEconomicAgentAsync(string installationCnpj, string company);
    }
}