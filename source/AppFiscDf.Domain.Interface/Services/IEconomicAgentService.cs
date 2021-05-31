using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IEconomicAgentService
    {
        Task<IEnumerable<EconomicAgentResponse>> ListAsync();

        Task<IEnumerable<EconomicAgentResponse>> ListByEconomicAgentAsync(string installationCnpj, string company);
    }
}