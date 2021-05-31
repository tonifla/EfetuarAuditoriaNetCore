using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IUfRepository : IRepository<Uf>
    {
        Task<IEnumerable<Uf>> GetListAsync();

        Task<IEnumerable<Uf>> GetListByUfAsync(string ufAcronym, string name);
    }
}