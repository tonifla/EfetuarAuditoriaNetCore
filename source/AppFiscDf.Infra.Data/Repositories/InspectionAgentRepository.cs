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
    public class InspectionAgentRepository : Repository<InspectionAgent>, IInspectionAgentRepository
    {
        private readonly SqlContext _context;

        public InspectionAgentRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InspectionAgent>> GetListAsync()
        {
            return await _context.InspectionAgent
                         .Where(p => p.Status)
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<InspectionAgent>> GetListByInspectionAgentAsync(string name, string registry)
        {
            return await _context.InspectionAgent
                         .Where(p => p.Status
                                  && (p.Name.ToUpper().Contains(string.IsNullOrEmpty(name) ? name : name.ToUpper())
                                      || p.Registry == registry))
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<InspectionAgent>> GetListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page)
        {
            var numberRecords = 40;

            if (tipoNrUfOrInspectionAgent)
            {
                return await _context.InspectionAgent
                         .Include(a => a.SequentialList.Where(s => !s.InspectionDocumentList.Any(i => i.SequentialCode == s.SequentialCode)))
                         .Where(p => p.Status && p.NrUfId == nrUfId)
                         .OrderBy(p => p.Name)
                         .Skip(numberRecords * (page - 1))
                         .Take(numberRecords)
                         .AsNoTracking()
                         .ToListAsync();
            }
            else
            {
                return await _context.InspectionAgent
                         .Include(a => a.SequentialList.Where(s => !s.InspectionDocumentList.Any(i => i.SequentialCode == s.SequentialCode)))
                         .Where(p => p.Status && p.InspectionAgentId == inspectionAgentId)
                         .OrderBy(p => p.Name)
                         .Skip(numberRecords * (page - 1))
                         .Take(numberRecords)
                         .AsNoTracking()
                         .ToListAsync();
            }
        }

        public async Task<InspectionAgent> GetFindByInspectionAgentAsync(string login, string cpf)
        {
            return await _context.InspectionAgent
                         .Where(p => p.Status
                                     && (p.Login.ToLower() == login.ToLower() || string.IsNullOrEmpty(login))
                                     && (p.Cpf == cpf || string.IsNullOrEmpty(cpf)))
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}