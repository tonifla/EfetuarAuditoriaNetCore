using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocInspectionAgentConfiguration : IEntityTypeConfiguration<InsDocInspectionAgent>
    {
        public void Configure(EntityTypeBuilder<InsDocInspectionAgent> builder)
        {
            builder.HasKey(e => new { e.InspectionAgentId, e.InspectionDocumentId })
                    .HasName("KFIS_AGENTE_FISCALIZACAO_DF");

            builder.ToTable("TFIS_AGENTE_FISCALIZACAO_DF");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.InspectionAgentId)
                .HasColumnName("COD_AGENTE_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.Sort)
                .HasColumnName("NUM_ORDEM")
                .HasColumnType("NUMBER");

            builder.HasOne(e => e.InspectionAgent)
                .WithMany(p => p.InsDocInspectionAgentList)
                .HasForeignKey(e => e.InspectionAgentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.InspectionDocument)
                .WithMany(p => p.InsDocInspectionAgentList)
                .HasForeignKey(e => e.InspectionDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}