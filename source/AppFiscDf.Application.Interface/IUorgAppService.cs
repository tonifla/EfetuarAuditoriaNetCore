using AppFiscDf.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Interface
{
    public interface IUorgAppService
    {
        Task<MessageResponse<UorgResponse>> FindByUorgAsync(string acronym);
    }
}