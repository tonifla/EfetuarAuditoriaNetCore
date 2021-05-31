using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocWitnessConfiguration : IEntityTypeConfiguration<InsDocWitness>
    {
        public void Configure(EntityTypeBuilder<InsDocWitness> builder)
        {
            builder.HasKey(e => new { e.InsDocWitnessId, e.InspectionDocumentId })
                    .HasName("KFIS_TESTEMUNHA_DF");

            builder.ToTable("TFIS_TESTEMUNHA_DF");

            builder.Property(e => e.InsDocWitnessId)
                .HasColumnName("COD_TESTEMUNHA_DF")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.Name)
                .HasColumnName("NOM_TESTEMUNHA")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Document)
                .HasColumnName("NUM_DOCUMENTO")
                .HasMaxLength(20)
                .IsUnicode(false);

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
        }
    }
}