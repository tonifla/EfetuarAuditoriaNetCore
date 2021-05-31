using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class InsDocTypificationRepository : Repository<InsDocTypification>, IInsDocTypificationRepository
    {
        public InsDocTypificationRepository(SqlContext context)
            : base(context)
        {
        }
    }
}