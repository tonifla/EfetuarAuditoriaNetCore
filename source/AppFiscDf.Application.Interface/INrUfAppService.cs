using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface INrUfAppService
    {
        Task<MessageResponse<IEnumerable<NrUfResponse>>> ListAsync();
    }
}