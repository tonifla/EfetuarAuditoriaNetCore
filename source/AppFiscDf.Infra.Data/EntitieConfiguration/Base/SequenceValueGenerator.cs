using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.EntitieConfiguration.Base
{
    internal class SequenceValueGenerator : ValueGenerator<decimal>
    {
        private readonly string _sequenceName;

        public SequenceValueGenerator(string sequenceName)
        {
            _sequenceName = sequenceName;
        }

        public override bool GeneratesTemporaryValues => false;

        public override decimal Next(EntityEntry entry) => GetSequence(entry).Result;

        private async Task<decimal> GetSequence(EntityEntry entry)
        {
            using (var command = entry.Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT {_sequenceName}.NEXTVAL FROM DUAL";
                await entry.Context.Database.OpenConnectionAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return await reader.GetFieldValueAsync<decimal>(reader.GetOrdinal("NEXTVAL"));
                }
            }
        }
    }
}