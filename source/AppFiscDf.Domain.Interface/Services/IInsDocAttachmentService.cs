using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IInsDocAttachmentService
    {
        Task<IEnumerable<InsDocAttachmentRequestResponse>> ListByInsDocAttachmentAsync(decimal inspectionDocumentId);

        Task<InsDocAttachmentRequestResponse> FindByInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId);

        Task<InsDocAttachmentRequestResponse> FindByInsDocAttachmentAsync(string inspectionDocumentFinished);

        Task<InsDocAttachmentRequestResponse> InsertInsDocAttachmentAsync(InsDocAttachmentRequestResponse request);

        Task<InsDocAttachmentRequestResponse> DeleteInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId);
    }
}