using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IEconomicAgentReducedAppService
    {
        Task<MessageResponse<IEnumerable<EconomicAgentReducedResponse>>> ListAsync();

        Task<MessageResponse<IEnumerable<EconomicAgentReducedResponse>>> ListByEconomicAgentReducedAsync(string installationCnpj, string company);

        Task<byte[]> ListFileCsvReducedAsync();
    }
}