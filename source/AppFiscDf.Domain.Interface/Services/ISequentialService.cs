using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface ISequentialService
    {
        Task<IEnumerable<SequentialRequestResponse>> ListAsync();

        Task<IEnumerable<SequentialRequestResponse>> ListBySequentialAsync(decimal inspectionAgentId);

        Task<SequentialRequestResponse> FindBySequentialAsync(decimal inspectionAgentId);

        Task<SequentialRequestResponse> FindBySequentialInspectionAgentAsync(decimal inspectionAgentId, decimal sequentialCode);

        Task<SequentialRequestResponse> InsertSequentialAsync(decimal inspectionAgentId, decimal sequentialCode);

        Task<SequentialRequestResponse> DeleteSequentialAsync(decimal inspectionAgentId, decimal sequentialCode);
    }
}