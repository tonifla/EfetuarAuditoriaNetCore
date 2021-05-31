using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class InspectionDocumentRepository : Repository<InspectionDocument>, IInspectionDocumentRepository
    {
        private readonly SqlContext _context;

        public InspectionDocumentRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName)
        {
            if (finished)
            {
                return await _context.InspectionDocument
                             .Where(f => f.Finished == finished
                                         && _context.InsDocInspectionAgent.Any(i => i.InspectionDocumentId == f.InspectionDocumentId
                                                                                 && i.InspectionAgentId == inspectionAgentId)
                                         && (
                                                 (f.EndDate >= startDate.Date || startDate == DateTime.MinValue)
                                                 &&
                                                 (f.EndDate <= endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59) || endDate == DateTime.MinValue)
                                             )
                                         && (f.SequentialCode == sequentialCode || sequentialCode == 0)
                                         && (_context.InsDocEconomicAgent.Any(e => e.InspectionDocumentId == f.InspectionDocumentId
                                                                                && (e.CpfCnpj == cpfCnpj || string.IsNullOrEmpty(cpfCnpj))))
                                         && (_context.InsDocEconomicAgent.Any(e => e.InspectionDocumentId == f.InspectionDocumentId
                                                                                && (e.CompanyName.ToUpper().Contains(string.IsNullOrEmpty(companyName) ? companyName : companyName.ToUpper()) || string.IsNullOrEmpty(companyName))))
                                      )
                             .Include(f => f.InsDocSerialized)
                             .Include(f => f.InsDocServiceOrder)
                             .Include(f => f.InsDocEconomicAgent)
                             .Include(f => f.InsDocInspectionAgentList)
                             .Include(f => f.InsDocRepresentative)
                             .Include(f => f.InsDocTypificationList)
                             .Include(f => f.InsDocWitnessList)
                             .Include(f => f.InsDocAttachmentList)
                             .Include(f => f.Sequential)
                             .Include(f => f.Uf)
                             .OrderByDescending(p => p.EndDate)
                             .AsNoTracking()
                             .ToListAsync();
            }
            else
            {
                return await _context.InspectionDocument
                             .Where(r => r.Finished == finished
                                         && _context.InsDocInspectionAgent.Any(i => i.InspectionDocumentId == r.InspectionDocumentId
                                                                                 && i.InspectionAgentId == inspectionAgentId
                                                                                 && i.Sort == 1)
                                         && (
                                                 (r.StartDate >= startDate.Date || startDate == DateTime.MinValue)
                                                 &&
                                                 (r.StartDate <= endDate.Date || endDate == DateTime.MinValue)
                                             )
                                         && (r.SequentialCode == sequentialCode || sequentialCode == 0)
                                         && (_context.InsDocEconomicAgent.Any(e => e.InspectionDocumentId == r.InspectionDocumentId
                                                                                && (e.CpfCnpj == cpfCnpj || string.IsNullOrEmpty(cpfCnpj))))
                                         && (_context.InsDocEconomicAgent.Any(e => e.InspectionDocumentId == r.InspectionDocumentId
                                                                                && (e.CompanyName.ToUpper().Contains(string.IsNullOrEmpty(companyName) ? companyName : companyName.ToUpper()) || string.IsNullOrEmpty(companyName))))
                                      )
                             .Include(r => r.InsDocSerialized)
                             .Include(r => r.InsDocServiceOrder)
                             .Include(r => r.InsDocEconomicAgent)
                             .Include(r => r.InsDocInspectionAgentList)
                             .Include(r => r.InsDocRepresentative)
                             .Include(r => r.InsDocTypificationList)
                             .Include(r => r.InsDocWitnessList)
                             .Include(r => r.InsDocAttachmentList)
                             .Include(r => r.Sequential)
                             .Include(r => r.Uf)
                             .OrderByDescending(p => p.StartDate)
                             .AsNoTracking()
                             .ToListAsync();
            }
        }

        public async Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(decimal inspectionAgentId, bool finished)
        {
            return await _context.InspectionDocument
                         .Where(p => _context.InsDocInspectionAgent.Any(i => i.InspectionDocumentId == p.InspectionDocumentId
                                                                          && i.InspectionAgentId == inspectionAgentId
                                                                          && i.Sort == 1)
                                     && p.Finished == finished)
                         .Include(p => p.InsDocSerialized)
                         .Include(p => p.InsDocServiceOrder)
                         .Include(p => p.InsDocEconomicAgent)
                         .Include(p => p.InsDocInspectionAgentList)
                         .Include(p => p.InsDocRepresentative)
                         .Include(p => p.InsDocTypificationList)
                         .Include(p => p.InsDocWitnessList)
                         .Include(p => p.InsDocAttachmentList)
                         .Include(p => p.Sequential)
                         .Include(p => p.Uf)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page)
        {
            var numberRecords = 30;

            return await _context.InspectionDocument
                         .Where(w => (_context.InsDocInspectionAgent.Any(i => i.InspectionDocumentId == w.InspectionDocumentId
                                                                           && ((i.InspectionAgentId == inspectionAgentId && i.Sort == 1) || inspectionAgentId == 0)))
                         && (
                                 (
                                  typeInspectionDocument == 0 && !w.Finished
                                  &&
                                  (w.StartDate >= startDate.Date || startDate == DateTime.MinValue)
                                  &&
                                  (w.StartDate <= endDate.Date || endDate == DateTime.MinValue)
                                 )
                                 ||
                                 (
                                  typeInspectionDocument == 1 && w.Finished
                                  &&
                                  (w.EndDate >= startDate.Date || startDate == DateTime.MinValue)
                                  &&
                                  (w.EndDate <= endDate.AddHours(23).AddMinutes(59).AddSeconds(59) || endDate == DateTime.MinValue)
                                 )
                                 ||
                                 (
                                  typeInspectionDocument == 2
                                  &&
                                  (w.EndDate >= startDate.Date || startDate == DateTime.MinValue)
                                  &&
                                  (w.EndDate <= endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59) || endDate == DateTime.MinValue)
                                  ||
                                  typeInspectionDocument == 2
                                  &&
                                  (w.StartDate >= startDate.Date || startDate == DateTime.MinValue)
                                  &&
                                  (w.StartDate <= endDate.Date || endDate == DateTime.MinValue)
                                 )
                          )

                         && (w.SequentialCode == sequentialCode || sequentialCode == 0)
                         && (_context.InsDocEconomicAgent.Any(e => string.IsNullOrEmpty(economicAgentCpfCnpj) ? string.IsNullOrEmpty(economicAgentCpfCnpj)
                                                                : (e.InspectionDocumentId == w.InspectionDocumentId && e.CpfCnpj == economicAgentCpfCnpj)))
                         && (_context.InsDocEconomicAgent.Any(e => string.IsNullOrEmpty(economicAgentCompanyName) ? string.IsNullOrEmpty(economicAgentCompanyName)
                                                                : (e.InspectionDocumentId == w.InspectionDocumentId && e.CompanyName.ToUpper().Contains(economicAgentCompanyName.ToUpper()))))
                         && (_context.Uf.Any(u => nrUfId == 0 ? nrUfId == 0
                                               : _context.NrUf.Any(n => n.NrUfId == u.NrUfId && u.UfReference == w.UfReference && n.NrUfId == nrUfId)))
                         && (_context.Uf.Any(u => string.IsNullOrEmpty(ufAcronym) ? string.IsNullOrEmpty(ufAcronym)
                                               : (u.UfReference == w.UfReference && u.UfAcronym.ToUpper().Contains(ufAcronym.ToUpper()))))
                         && (_context.InsDocServiceOrder.Any(o => orderServiceYear == 0 ? orderServiceYear == 0
                                                                : (o.InspectionDocumentId == w.InspectionDocumentId && o.Year == orderServiceYear)))
                         && (_context.InsDocServiceOrder.Any(o => orderServiceNumber == 0 ? orderServiceNumber == 0
                                                                : (o.InspectionDocumentId == w.InspectionDocumentId && o.Number == orderServiceNumber)))
                         )
                         .Include(w => w.InsDocSerialized)
                         .Include(w => w.InsDocServiceOrder)
                         .Include(w => w.InsDocEconomicAgent)
                         .Include(w => w.InsDocInspectionAgentList)
                         .Include(w => w.InsDocRepresentative)
                         .Include(w => w.InsDocTypificationList)
                         .Include(w => w.InsDocWitnessList)
                         .Include(w => w.InsDocAttachmentList)
                         .Include(w => w.Sequential)
                         .Include(w => w.Uf)
                         .ThenInclude(w => w.NrUf)
                         .Skip(numberRecords * (page - 1))
                         .Take(numberRecords)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<InspectionDocument> GetFindByInspectionDocumentAsync(decimal inspectionDocumentId)
        {
            return await _context.InspectionDocument
                         .Where(i => i.InspectionDocumentId == inspectionDocumentId)
                         .Include(i => i.InsDocSerialized)
                         .Include(i => i.InsDocServiceOrder)
                         .Include(i => i.InsDocEmailList)
                         .Include(i => i.InsDocEconomicAgent)
                         .Include(i => i.InsDocInspectionAgentList)
                         .Include(i => i.InsDocRepresentative)
                         .Include(i => i.InsDocTypificationList)
                         .Include(i => i.InsDocWitnessList)
                         .Include(i => i.InsDocAttachmentList)
                         .Include(i => i.Sequential)
                         .Include(i => i.Uf)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<InspectionDocument> GetFindByInspectionDocumentAsync(decimal inspectionAgentId, decimal sequentialCode, bool finished)
        {
            return await _context.InspectionDocument
                         .Where(t => _context.InsDocInspectionAgent.Any(i => i.InspectionAgentId == inspectionAgentId
                                                                          && i.InspectionDocumentId == t.InspectionDocumentId)
                                     && t.SequentialCode == sequentialCode
                                     && t.Finished == finished)
                         .Include(t => t.InsDocSerialized)
                         .Include(t => t.InsDocServiceOrder)
                         .Include(t => t.InsDocEconomicAgent)
                         .Include(t => t.InsDocInspectionAgentList)
                         .Include(t => t.InsDocRepresentative)
                         .Include(t => t.InsDocTypificationList)
                         .Include(t => t.InsDocWitnessList)
                         .Include(t => t.InsDocAttachmentList)
                         .Include(t => t.Sequential)
                         .Include(t => t.Uf)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}