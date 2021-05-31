using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class UfService : IUfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UfResponse>> ListAsync()
        {
            var uf = await _unitOfWork.UfRepository.GetListAsync();
            return await Task.FromResult(uf.Select(uf => uf.ConvertToResponse()));
        }

        public async Task<IEnumerable<UfResponse>> ListByUfAsync(string ufAcronym, string name)
        {
            var uf = await _unitOfWork.UfRepository.GetListByUfAsync(ufAcronym, name);
            return await Task.FromResult(uf.Select(uf => uf.ConvertToResponse()));
        }
    }
}