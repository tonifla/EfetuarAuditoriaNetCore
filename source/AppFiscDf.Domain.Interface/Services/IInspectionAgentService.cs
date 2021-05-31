using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IInspectionAgentService
    {
        Task<IEnumerable<InspectionAgentResponse>> ListAsync();

        Task<IEnumerable<InspectionAgentResponse>> ListByInspectionAgentAsync(string name, string registry);

        Task<IEnumerable<InspectionAgentResponse>> ListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page);

        Task<InspectionAgentResponse> FindByInspectionAgentAsync(string login, string cpf);
    }
}