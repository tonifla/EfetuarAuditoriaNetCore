using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class InsDocAttachmentService : IInsDocAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsDocAttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InsDocAttachmentRequestResponse>> ListByInsDocAttachmentAsync(decimal inspectionDocumentId)
        {
            var insDocAttachment = await _unitOfWork.InsDocAttachmentRepository.GetListByInsDocAttachmentAsync(inspectionDocumentId);
            return await Task.FromResult(insDocAttachment.Select(insDocAttachment => insDocAttachment.ConvertToResponse()));
        }

        public async Task<InsDocAttachmentRequestResponse> FindByInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var insDocAttachment = await _unitOfWork.InsDocAttachmentRepository.GetFindByInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);
            return await Task.FromResult(InsDocAttachmentMapper.ConvertObjectToResponse(insDocAttachment));
        }

        public async Task<InsDocAttachmentRequestResponse> FindByInsDocAttachmentAsync(string inspectionDocumentFinished)
        {
            var insDocAttachment = await _unitOfWork.InsDocAttachmentRepository.GetFindByInsDocAttachmentAsync(inspectionDocumentFinished);
            return await Task.FromResult(InsDocAttachmentMapper.ConvertObjectToResponse(insDocAttachment));
        }

        public async Task<InsDocAttachmentRequestResponse> InsertInsDocAttachmentAsync(InsDocAttachmentRequestResponse request)
        {
            var insDocAttachment = InsDocAttachmentMapper.ConvertRequestToObject(request);
            var insert = await _unitOfWork.InsDocAttachmentRepository.AddAsync(insDocAttachment).ConfigureAwait(false);
            return await Task.FromResult(InsDocAttachmentMapper.ConvertObjectToResponse(insert));
        }

        public async Task<InsDocAttachmentRequestResponse> DeleteInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var insDocAttachment = await _unitOfWork.InsDocAttachmentRepository.GetFindByInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);
            var delete = await _unitOfWork.InsDocAttachmentRepository.RemoveAsync(insDocAttachment).ConfigureAwait(false);
            return await Task.FromResult(InsDocAttachmentMapper.ConvertObjectToResponse(delete));
        }
    }
}