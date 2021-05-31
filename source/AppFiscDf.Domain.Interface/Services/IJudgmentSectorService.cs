using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IJudgmentSectorService
    {
        Task<IEnumerable<JudgmentSectorRequestResponse>> ListAsync();
    }
}