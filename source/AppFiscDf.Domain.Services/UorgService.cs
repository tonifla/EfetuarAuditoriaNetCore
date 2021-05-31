using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class UorgService : IUorgService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UorgService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UorgResponse> FindByUorgAsync(string acronym)
        {
            var uorg = await _unitOfWork.UorgRepository.GetFindByUorgAsync(acronym);
            return await Task.FromResult(UorgMapper.ConvertObjectToResponse(uorg));
        }
    }
}