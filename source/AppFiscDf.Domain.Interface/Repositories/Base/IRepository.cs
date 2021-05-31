using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.Repositories.Base
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity, decimal id);

        Task<TEntity> RemoveAsync(TEntity entity);

        Task RemoveRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> GetAsync(decimal id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllWithFiltersAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetObjWithFiltersAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}