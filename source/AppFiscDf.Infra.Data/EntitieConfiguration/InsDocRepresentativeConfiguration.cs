using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocRepresentativeConfiguration : IEntityTypeConfiguration<InsDocRepresentative>
    {
        public void Configure(EntityTypeBuilder<InsDocRepresentative> builder)
        {
            builder.HasKey(e => e.InspectionDocumentId)
                    .HasName("KFIS_REPRESENTANTE_DF");

            builder.ToTable("TFIS_REPRESENTANTE_DF");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.SignatureDate)
                .HasColumnName("DHA_ASSINATURA")
                .HasColumnType("DATE");

            builder.Property(e => e.Employment)
                .HasColumnName("DSC_CARGO")
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.SignatureImage)
                .HasColumnName("IMG_ASSINATURA")
                .HasColumnType("BLOB");

            builder.Property(e => e.Name)
                .HasColumnName("NOM_REPRESENTANTE")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Document)
                .HasColumnName("NUM_DOCUMENTO")
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}