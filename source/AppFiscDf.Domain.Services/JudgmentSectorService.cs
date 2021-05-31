using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class JudgmentSectorService : IJudgmentSectorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JudgmentSectorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JudgmentSectorRequestResponse>> ListAsync()
        {
            var judgmentSector = await _unitOfWork.JudgmentSectorRepository.GetListAsync();
            return await Task.FromResult(judgmentSector.Select(judgmentSector => judgmentSector.ConvertToRequestResponse()));
        }
    }
}