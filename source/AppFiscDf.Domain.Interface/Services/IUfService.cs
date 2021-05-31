using AppFiscDf.Application.Model.RequestResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Services
{
    public interface IUfService
    {
        Task<IEnumerable<UfResponse>> ListAsync();

        Task<IEnumerable<UfResponse>> ListByUfAsync(string ufAcronym, string name);
    }
}