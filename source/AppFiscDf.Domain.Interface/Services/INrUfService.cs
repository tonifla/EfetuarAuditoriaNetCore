using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface INrUfService
    {
        Task<IEnumerable<NrUfResponse>> ListAsync();
    }
}