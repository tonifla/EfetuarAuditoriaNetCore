using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.Repositories
{
    public class UfRepository : Repository<Uf>, IUfRepository
    {
        private readonly SqlContext _context;

        public UfRepository(SqlContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Uf>> GetListAsync()
        {
            return await _context.Uf
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<Uf>> GetListByUfAsync(string ufAcronym, string name)
        {
            return await _context.Uf
                         .Where(p => p.UfAcronym.ToUpper().Contains(string.IsNullOrEmpty(ufAcronym) ? ufAcronym : ufAcronym.ToUpper()) ||
                                     p.Name.ToUpper().Contains(string.IsNullOrEmpty(name) ? name : name.ToUpper()))
                         .OrderBy(p => p.Name)
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}