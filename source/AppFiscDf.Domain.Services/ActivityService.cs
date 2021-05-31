using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ActivityResponse>> ListAsync()
        {
            var activity = await _unitOfWork.ActivityRepository.GetListAsync();
            return await Task.FromResult(activity.Select(activity => activity.ConvertToResponse()));
        }

        public async Task<IEnumerable<ActivityResponse>> ListByActivityAsync(string name)
        {
            var activity = await _unitOfWork.ActivityRepository.GetListByActivityAsync(name);
            return await Task.FromResult(activity.Select(activity => activity.ConvertToResponse()));
        }
    }
}