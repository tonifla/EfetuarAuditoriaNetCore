using AppFiscDf.Domain.Interface.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                return null;

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, decimal id)
        {
            if (entity == null)
                return null;

            TEntity existing = await _context.Set<TEntity>().FindAsync(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).State = EntityState.Modified;
            }
            return existing;
        }

        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            if (entity == null)
                return null;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task RemoveRangeAsync(ICollection<TEntity> entities)
        {
            if (entities == null)
                return Task.FromResult<TEntity>(null);

            _context.Set<TEntity>().RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(decimal id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllWithFiltersAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().Where(filter).ToListAsync().ConfigureAwait(false);

        public async Task<TEntity> GetObjWithFiltersAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().FirstOrDefaultAsync(filter).ConfigureAwait(false);

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await _context.Set<TEntity>().AnyAsync(filter).ConfigureAwait(false);

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.DisposeAsync();
                }

                disposedValue = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}