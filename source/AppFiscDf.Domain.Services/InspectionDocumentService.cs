using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class InspectionDocumentService : IInspectionDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionDocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InspectionDocumentRequestResponse>> ListByInspectionDocumentAsync(bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetListByInspectionDocumentAsync(finished, inspectionAgentId, startDate, endDate, sequentialCode, cpfCnpj, companyName);
            return await Task.FromResult(inspectionDocument.Select(inspectionDocument => inspectionDocument.ConvertToResponse()));
        }

        public async Task<IEnumerable<InspectionDocumentReducedResponse>> ListByInspectionDocumentAsync(decimal inspectionAgentId, bool finished)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetListByInspectionDocumentAsync(inspectionAgentId, finished);
            return await Task.FromResult(inspectionDocument.Select(inspectionDocument => InspectionDocumentMapper.ConvertObjectToResponseReduced(inspectionDocument)));
        }

        public async Task<IEnumerable<InspectionDocumentRequestResponse>> ListByInspectionDocumentAsync(int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetListByInspectionDocumentAsync(typeInspectionDocument, inspectionAgentId, startDate, endDate, sequentialCode, economicAgentCpfCnpj, economicAgentCompanyName, nrUfId, ufAcronym, orderServiceYear, orderServiceNumber, page);
            return await Task.FromResult(inspectionDocument.Select(inspectionDocument => inspectionDocument.ConvertToResponse()));
        }

        public async Task<InspectionDocumentRequestResponse> FindByInspectionDocumentAsync(decimal inspectionDocumentId)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetFindByInspectionDocumentAsync(inspectionDocumentId);
            return await Task.FromResult(InspectionDocumentMapper.ConvertObjectToResponse(inspectionDocument));
        }

        public async Task<InspectionDocumentRequestResponse> FindByInspectionDocumentAsync(decimal inspectionAgentId, decimal sequentialCode, bool finished)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetFindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished);
            return await Task.FromResult(InspectionDocumentMapper.ConvertObjectToResponse(inspectionDocument));
        }

        public async Task<InspectionDocumentRequestResponse> InsertInspectionDocumentAsync(InspectionDocumentRequestResponse request)
        {
            var inspectionDocument = InspectionDocumentMapper.ConvertRequestToObject(request);
            inspectionDocument.Finished = inspectionDocument.EndDate != null;

            var insert = await _unitOfWork.InspectionDocumentRepository.AddAsync(inspectionDocument).ConfigureAwait(false);
            return await Task.FromResult(InspectionDocumentMapper.ConvertObjectToResponse(insert));
        }

        public async Task<InspectionDocumentRequestResponse> UpdateInspectionDocumentAsync(InspectionDocumentRequestResponse request)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetAsync(request.InspectionDocumentId);
            inspectionDocument = InspectionDocumentMapper.ConvertObjectUpdated(request, inspectionDocument);

            inspectionDocument.Finished = inspectionDocument.EndDate != null;

            var update = await _unitOfWork.InspectionDocumentRepository.UpdateAsync(inspectionDocument, request.InspectionDocumentId);
            return await Task.FromResult(InspectionDocumentMapper.ConvertObjectToResponse(update));
        }

        public async Task<InspectionDocumentRequestResponse> DeleteInspectionDocumentAsync(decimal inspectionAgentId, decimal inspectionDocumentId)
        {
            var inspectionDocument = await _unitOfWork.InspectionDocumentRepository.GetAsync(inspectionDocumentId);

            await _unitOfWork.InsDocAttachmentRepository.RemoveRangeAsync(inspectionDocument.InsDocAttachmentList).ConfigureAwait(false);
            await _unitOfWork.InsDocTypificationRepository.RemoveRangeAsync(inspectionDocument.InsDocTypificationList).ConfigureAwait(false);
            await _unitOfWork.InsDocWitnessRepository.RemoveRangeAsync(inspectionDocument.InsDocWitnessList).ConfigureAwait(false);
            await _unitOfWork.InsDocInspectionAgentRepository.RemoveRangeAsync(inspectionDocument.InsDocInspectionAgentList).ConfigureAwait(false);
            await _unitOfWork.InsDocRepresentativeRepository.RemoveAsync(inspectionDocument.InsDocRepresentative).ConfigureAwait(false);
            await _unitOfWork.InsDocEconomicAgentRepository.RemoveAsync(inspectionDocument.InsDocEconomicAgent).ConfigureAwait(false);
            await _unitOfWork.InsDocServiceOrderRepository.RemoveAsync(inspectionDocument.InsDocServiceOrder).ConfigureAwait(false);
            await _unitOfWork.InsDocSerializedRepository.RemoveAsync(inspectionDocument.InsDocSerialized).ConfigureAwait(false);

            var delete = await _unitOfWork.InspectionDocumentRepository.RemoveAsync(inspectionDocument).ConfigureAwait(false);
            return await Task.FromResult(InspectionDocumentMapper.ConvertObjectToResponse(delete));
        }
    }
}