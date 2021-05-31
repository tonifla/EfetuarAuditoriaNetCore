using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface INrUfRepository : IRepository<NrUf>
    {
        Task<IEnumerable<NrUf>> GetListAsync();
    }
}