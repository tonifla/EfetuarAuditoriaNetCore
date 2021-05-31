using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class SequentialConfiguration : IEntityTypeConfiguration<Sequential>
    {
        public void Configure(EntityTypeBuilder<Sequential> builder)
        {
            builder.HasKey(e => e.SequentialCode)
                    .HasName("KFIS_SEQUENCIAL");

            builder.ToTable("TFIS_SEQUENCIAL");

            builder.Property(e => e.SequentialCode)
                .HasColumnName("COD_SEQUENCIAL")
                .HasColumnType("NUMBER");

            builder.Property(e => e.InspectionAgentId)
                .HasColumnName("COD_AGENTE_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.HasOne(e => e.InspectionAgent)
                .WithMany(p => p.SequentialList)
                .HasForeignKey(e => e.InspectionAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}