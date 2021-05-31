using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IInsDocAttachmentRepository : IRepository<InsDocAttachment>
    {
        Task<IEnumerable<InsDocAttachment>> GetListByInsDocAttachmentAsync(decimal inspectionDocumentId);

        Task<InsDocAttachment> GetFindByInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId);

        Task<InsDocAttachment> GetFindByInsDocAttachmentAsync(string inspectionDocumentFinished);
    }
}