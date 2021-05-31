using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class NrUfService : INrUfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NrUfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NrUfResponse>> ListAsync()
        {
            var nrUf = await _unitOfWork.NrUfRepository.GetListAsync();
            return await Task.FromResult(nrUf.Select(nrUf => nrUf.ConvertToResponse()));
        }
    }
}