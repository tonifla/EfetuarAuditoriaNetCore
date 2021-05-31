using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IInspectionAgentAppService
    {
        Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListAsync();

        Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListByInspectionAgentAsync(string name, string registry);

        Task<MessageResponse<IEnumerable<InspectionAgentResponse>>> ListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page);

        Task<MessageResponse<InspectionAgentResponse>> FindByInspectionAgentAsync(string login, string cpf);

        Task<IEnumerable<InspectionAgentResponse>> ListFileJsonAsync();
    }
}