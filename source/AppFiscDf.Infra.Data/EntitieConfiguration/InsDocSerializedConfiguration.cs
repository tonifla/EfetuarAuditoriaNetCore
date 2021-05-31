using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocSerializedConfiguration : IEntityTypeConfiguration<InsDocSerialized>
    {
        public void Configure(EntityTypeBuilder<InsDocSerialized> builder)
        {
            builder.HasKey(e => e.InspectionDocumentId)
                .HasName("KFIS_SERIALIZADO_DF");

            builder.ToTable("TFIS_SERIALIZADO_DF");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO");

            builder.Property(e => e.JsonString)
                .HasColumnName("DSC_SERIALIZADO_DF")
                .HasColumnType("CLOB");
        }
    }
}