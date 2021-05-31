using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface ISequentialAppService
    {
        Task<MessageResponse<IEnumerable<SequentialRequestResponse>>> ListAsync();

        Task<IEnumerable<SequentialRequestResponse>> ListBySequentialAsync(decimal inspectionAgentId);

        Task<MessageResponse<SequentialRequestResponse>> FindBySequentialAsync(decimal inspectionAgentId);

        Task<MessageResponse<SequentialRequestResponse>> InsertSequentialAsync(decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd);

        Task<MessageResponse<SequentialRequestResponse>> DeleteSequentialAsync(decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd);
    }
}