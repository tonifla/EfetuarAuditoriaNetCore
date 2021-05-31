using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IActivityAppService
    {
        Task<MessageResponse<IEnumerable<ActivityResponse>>> ListAsync();

        Task<MessageResponse<IEnumerable<ActivityResponse>>> ListByActivityAsync(string name);
    }
}