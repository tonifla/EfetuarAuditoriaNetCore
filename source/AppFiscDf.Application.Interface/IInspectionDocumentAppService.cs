using AppFiscDf.Application.Model.RequestResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IInspectionDocumentAppService
    {
        Task<MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>> ListByInspectionDocumentAsync(bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName);

        Task<IEnumerable<InspectionDocumentReducedResponse>> ListByInspectionDocumentAsync(decimal inspectionAgentId, bool finished);

        Task<MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>> ListByInspectionDocumentAsync(int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page);

        Task<InspectionDocumentRequestResponse> FindByInspectionDocumentAsync(decimal inspectionDocumentId);

        Task<MessageResponse<InspectionDocumentRequestResponse>> FindByInspectionDocumentAsync(decimal inspectionAgentId, decimal sequentialCode, bool finished);

        Task<InspectionDocumentRequestResponse> InsertInspectionDocumentAsync(InspectionDocumentRequestResponse request);

        Task<InspectionDocumentRequestResponse> UpdateInspectionDocumentAsync(InspectionDocumentRequestResponse request);

        Task<InspectionDocumentRequestResponse> DeleteInspectionDocumentAsync(decimal inspectionAgentId, decimal inspectionDocumentId);
    }
}