using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class EconomicAgentService : IEconomicAgentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EconomicAgentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EconomicAgentResponse>> ListAsync()
        {
            var economicAgent = await _unitOfWork.EconomicAgentRepository.GetListAsync();
            return await Task.FromResult(economicAgent.Select(economicAgent => economicAgent.ConvertToResponse()));
        }

        public async Task<IEnumerable<EconomicAgentResponse>> ListByEconomicAgentAsync(string installationCnpj, string company)
        {
            var economicAgent = await _unitOfWork.EconomicAgentRepository.GetListByEconomicAgentAsync(installationCnpj, company);
            return await Task.FromResult(economicAgent.Select(economicAgent => economicAgent.ConvertToResponse()));
        }
    }
}