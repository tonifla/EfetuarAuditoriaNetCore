using AppFiscDf.Application.Model.RequestResponse;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IUorgService
    {
        Task<UorgResponse> FindByUorgAsync(string acronym);
    }
}