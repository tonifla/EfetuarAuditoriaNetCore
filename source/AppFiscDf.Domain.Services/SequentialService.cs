using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class SequentialService : ISequentialService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SequentialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SequentialRequestResponse>> ListAsync()
        {
            var sequential = await _unitOfWork.SequentialRepository.GetListAsync();
            return await Task.FromResult(sequential.Select(sequential => sequential.ConvertToRequestResponse()));
        }

        public async Task<IEnumerable<SequentialRequestResponse>> ListBySequentialAsync(decimal inspectionAgentId)
        {
            var sequential = await _unitOfWork.SequentialRepository.GetListBySequentialAsync(inspectionAgentId);
            return await Task.FromResult(sequential.Select(sequential => sequential.ConvertToRequestResponse()));
        }

        public async Task<SequentialRequestResponse> FindBySequentialAsync(decimal inspectionAgentId)
        {
            var sequential = await _unitOfWork.SequentialRepository.GetFindBySequentialAsync(inspectionAgentId);
            return await Task.FromResult(SequentialMapper.ConvertObjectToResponse(sequential));
        }

        public async Task<SequentialRequestResponse> FindBySequentialInspectionAgentAsync(decimal inspectionAgentId, decimal sequentialCode)
        {
            var sequential = await _unitOfWork.SequentialRepository.GetFindBySequentialInspectionAgentAsync(inspectionAgentId, sequentialCode);
            return await Task.FromResult(SequentialMapper.ConvertObjectToResponse(sequential));
        }

        public async Task<SequentialRequestResponse> InsertSequentialAsync(decimal inspectionAgentId, decimal sequentialCode)
        {
            var sequential = SequentialMapper.ConvertRequestToObject(inspectionAgentId, sequentialCode);
            var insert = await _unitOfWork.SequentialRepository.AddAsync(sequential).ConfigureAwait(false);
            return await Task.FromResult(SequentialMapper.ConvertObjectToResponse(insert));
        }

        public async Task<SequentialRequestResponse> DeleteSequentialAsync(decimal inspectionAgentId, decimal sequentialCode)
        {
            var sequential = await _unitOfWork.SequentialRepository.GetFindBySequentialInspectionAgentAsync(inspectionAgentId, sequentialCode);
            var delete = await _unitOfWork.SequentialRepository.RemoveAsync(sequential).ConfigureAwait(false);
            return await Task.FromResult(SequentialMapper.ConvertObjectToResponse(delete));
        }
    }
}