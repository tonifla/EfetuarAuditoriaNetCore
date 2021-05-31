using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IInsDocAttachmentAppService
    {
        Task<MessageResponse<IEnumerable<InsDocAttachmentRequestResponse>>> ListByInsDocAttachmentAsync(decimal inspectionDocumentId);

        Task<MessageResponse<InsDocAttachmentRequestResponse>> GetFileInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId);

        Task<MessageResponse<InsDocAttachmentRequestResponse>> GetFileInsDocAttachmentAsync(string nameAttachmentInsDocFinished);

        Task<MessageResponse<InsDocAttachmentRequestResponse>> InsertInsDocAttachmentAsync(InsDocAttachmentRequestResponse request);

        Task<MessageResponse<InsDocAttachmentRequestResponse>> DeleteInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId);
    }
}