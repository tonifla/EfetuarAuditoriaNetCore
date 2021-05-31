using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IJudgmentSectorAppService
    {
        Task<MessageResponse<IEnumerable<JudgmentSectorRequestResponse>>> ListAsync();
    }
}