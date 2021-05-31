using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IEconomicAgentAppService
    {
        Task<MessageResponse<IEnumerable<EconomicAgentResponse>>> ListAsync();

        Task<MessageResponse<IEnumerable<EconomicAgentResponse>>> ListByEconomicAgentAsync(string installationCnpj, string company);

        Task<byte[]> ListFileCsvAsync();
    }
}