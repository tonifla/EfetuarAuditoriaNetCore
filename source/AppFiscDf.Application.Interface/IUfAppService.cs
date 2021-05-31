using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IUfAppService
    {
        Task<MessageResponse<IEnumerable<UfResponse>>> ListAsync();

        Task<MessageResponse<IEnumerable<UfResponse>>> ListByUfAsync(string ufAcronym, string name);
    }
}