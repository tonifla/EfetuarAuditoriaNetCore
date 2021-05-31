using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class InsDocAttachmentRepository : Repository<InsDocAttachment>, IInsDocAttachmentRepository
    {
        private readonly SqlContext _context;

        public InsDocAttachmentRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InsDocAttachment>> GetListByInsDocAttachmentAsync(decimal inspectionDocumentId)
        {
            return await _context.InsDocAttachment
                         .Where(p => p.InspectionDocumentId == inspectionDocumentId)
                         .OrderBy(p => p.AttachmentDate)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<InsDocAttachment> GetFindByInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            return await _context.InsDocAttachment
                         .Where(p => p.InspectionDocumentId == inspectionDocumentId
                                  && p.InsDocAttachmentId == insDocAttachmentId)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<InsDocAttachment> GetFindByInsDocAttachmentAsync(string inspectionDocumentFinished)
        {
            return await _context.InsDocAttachment
                         .Where(p => p.Name.ToUpper() == inspectionDocumentFinished.ToUpper())
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}