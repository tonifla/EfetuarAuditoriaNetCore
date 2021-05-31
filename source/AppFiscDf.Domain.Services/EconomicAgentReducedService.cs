using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class EconomicAgentReducedService : IEconomicAgentReducedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EconomicAgentReducedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EconomicAgentReducedResponse>> ListAsync()
        {
            var economicAgentReduced = await _unitOfWork.EconomicAgentReducedRepository.GetListAsync();
            return await Task.FromResult(economicAgentReduced.Select(economicAgentReduced => economicAgentReduced.ConvertToResponse()));
        }

        public async Task<IEnumerable<EconomicAgentReducedResponse>> ListByEconomicAgentReducedAsync(string installationCnpj, string company)
        {
            var economicAgentReduced = await _unitOfWork.EconomicAgentReducedRepository.GetListByEconomicAgentReducedAsync(installationCnpj, company);
            return await Task.FromResult(economicAgentReduced.Select(economicAgentReduced => economicAgentReduced.ConvertToResponse()));
        }
    }
}