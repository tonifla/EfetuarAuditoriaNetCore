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
    public class SequentialRepository : Repository<Sequential>, ISequentialRepository
    {
        private readonly SqlContext _context;

        public SequentialRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sequential>> GetListAsync()
        {
            return await _context.Sequential
                         .Include(i => i.InspectionDocumentList)
                         .Where(p => !_context.InspectionDocument.Any(s => s.SequentialCode == p.SequentialCode))
                         .OrderBy(p => p.InspectionAgentId)
                         .ThenBy(p => p.SequentialCode)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<Sequential>> GetListBySequentialAsync(decimal inspectionAgentId)
        {
            return await _context.Sequential
                         .Where(p => p.InspectionAgentId == inspectionAgentId
                                  && !_context.InspectionDocument.Any(s => s.SequentialCode == p.SequentialCode))
                         .OrderBy(p => p.SequentialCode)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<Sequential> GetFindBySequentialAsync(decimal inspectionAgentId)
        {
            return await _context.Sequential
                         .Where(p => p.InspectionAgentId == inspectionAgentId
                                  && !_context.InspectionDocument.Any(s => s.SequentialCode == p.SequentialCode))
                         .OrderBy(p => p.SequentialCode)
                         .AsNoTracking()
                         .FirstOrDefaultAsync();
        }

        public async Task<Sequential> GetFindBySequentialInspectionAgentAsync(decimal inspectionAgentId, decimal sequentialCode)
        {
            return await _context.Sequential
                         .Where(p => p.InspectionAgentId == inspectionAgentId
                                  && p.SequentialCode == sequentialCode
                                  && !_context.InspectionDocument.Any(s => s.SequentialCode == p.SequentialCode))
                         .OrderBy(p => p.SequentialCode)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}