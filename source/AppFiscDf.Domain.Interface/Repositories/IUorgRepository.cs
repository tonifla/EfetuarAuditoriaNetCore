using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IUorgRepository : IRepository<Uorg>
    {
        Task<Uorg> GetFindByUorgAsync(string acronym);
    }
}