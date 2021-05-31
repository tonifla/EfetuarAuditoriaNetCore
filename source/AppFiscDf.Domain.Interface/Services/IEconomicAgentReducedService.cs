using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IEconomicAgentReducedService
    {
        Task<IEnumerable<EconomicAgentReducedResponse>> ListAsync();

        Task<IEnumerable<EconomicAgentReducedResponse>> ListByEconomicAgentReducedAsync(string installationCnpj, string company);
    }
}