using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class InspectionAgentService : IInspectionAgentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionAgentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InspectionAgentResponse>> ListAsync()
        {
            var inspectionAgent = await _unitOfWork.InspectionAgentRepository.GetListAsync();
            return await Task.FromResult(inspectionAgent.Select(inspectionAgent => inspectionAgent.ConvertToResponse()));
        }

        public async Task<IEnumerable<InspectionAgentResponse>> ListByInspectionAgentAsync(string name, string registry)
        {
            var inspectionAgent = await _unitOfWork.InspectionAgentRepository.GetListByInspectionAgentAsync(name, registry);
            return await Task.FromResult(inspectionAgent.Select(inspectionAgent => inspectionAgent.ConvertToResponse()));
        }

        public async Task<IEnumerable<InspectionAgentResponse>> ListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page)
        {
            var inspectionAgent = await _unitOfWork.InspectionAgentRepository.GetListByInspectionAgentAsync(tipoNrUfOrInspectionAgent, nrUfId, inspectionAgentId, page);
            return await Task.FromResult(inspectionAgent.Select(inspectionAgent => inspectionAgent.ConvertToResponsePanel()));
        }

        public async Task<InspectionAgentResponse> FindByInspectionAgentAsync(string login, string cpf)
        {
            var inspectionAgent = await _unitOfWork.InspectionAgentRepository.GetFindByInspectionAgentAsync(login, cpf);
            return await Task.FromResult(InspectionAgentMapper.ConvertObjectToResponse(inspectionAgent));
        }
    }
}