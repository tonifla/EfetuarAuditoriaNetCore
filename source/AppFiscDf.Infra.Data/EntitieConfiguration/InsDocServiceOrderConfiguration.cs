using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocServiceOrderConfiguration : IEntityTypeConfiguration<InsDocServiceOrder>
    {
        public void Configure(EntityTypeBuilder<InsDocServiceOrder> builder)
        {
            builder.HasKey(e => e.InspectionDocumentId)
                    .HasName("KFIS_ORDEM_SERVICO_DF");

            builder.ToTable("TFIS_ORDEM_SERVICO_DF");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.Year)
                    .HasColumnName("NUM_ANO_ORDEM_SERVICO_DF");

            builder.Property(e => e.Number)
                    .HasColumnName("NUM_ORDEM_SERVICO_DF");

            builder.Property(e => e.NrUfId)
                    .HasColumnName("COD_NRUF");

            builder.Property(e => e.Type)
                .HasColumnName("IND_TIPO_ORDEM_SERVICO_DF");

            builder.HasOne(e => e.NrUf)
                    .WithMany(p => p.InsDocServiceOrderList)
                    .HasForeignKey(e => e.NrUfId);
        }
    }
}