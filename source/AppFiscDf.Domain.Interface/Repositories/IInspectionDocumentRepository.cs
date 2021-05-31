using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IInspectionDocumentRepository : IRepository<InspectionDocument>
    {
        Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName);

        Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(decimal inspectionAgentId, bool finished);

        Task<IEnumerable<InspectionDocument>> GetListByInspectionDocumentAsync(int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page);

        Task<InspectionDocument> GetFindByInspectionDocumentAsync(decimal inspectionDocumentId);

        Task<InspectionDocument> GetFindByInspectionDocumentAsync(decimal inspectionAgentId, decimal sequentialCode, bool finished);
    }
}