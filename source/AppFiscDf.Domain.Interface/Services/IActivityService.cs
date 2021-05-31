using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityResponse>> ListAsync();

        Task<IEnumerable<ActivityResponse>> ListByActivityAsync(string name);
    }
}