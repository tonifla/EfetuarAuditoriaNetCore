using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories
{
    public interface IInspectionAgentRepository : IRepository<InspectionAgent>
    {
        Task<IEnumerable<InspectionAgent>> GetListAsync();

        Task<IEnumerable<InspectionAgent>> GetListByInspectionAgentAsync(string name, string registry);

        Task<IEnumerable<InspectionAgent>> GetListByInspectionAgentAsync(bool tipoNrUfOrInspectionAgent, decimal nrUfId, decimal inspectionAgentId, int page);

        Task<InspectionAgent> GetFindByInspectionAgentAsync(string login, string cpf);
    }
}