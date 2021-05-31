using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IJudgmentSectorRepository : IRepository<JudgmentSector>
    {
        Task<IEnumerable<JudgmentSector>> GetListAsync();
    }
}