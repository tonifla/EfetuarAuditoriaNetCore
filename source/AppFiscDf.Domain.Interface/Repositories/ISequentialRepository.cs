using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface ISequentialRepository : IRepository<Sequential>
    {
        Task<IEnumerable<Sequential>> GetListAsync();

        Task<IEnumerable<Sequential>> GetListBySequentialAsync(decimal inspectionAgentId);

        Task<Sequential> GetFindBySequentialAsync(decimal inspectionAgentId);

        Task<Sequential> GetFindBySequentialInspectionAgentAsync(decimal inspectionAgentId, decimal sequentialCode);
    }
}