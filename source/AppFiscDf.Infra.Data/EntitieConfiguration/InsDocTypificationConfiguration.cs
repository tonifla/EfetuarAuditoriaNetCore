using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocTypificationConfiguration : IEntityTypeConfiguration<InsDocTypification>
    {
        public void Configure(EntityTypeBuilder<InsDocTypification> builder)
        {
            builder.HasKey(e => new { e.InsDocTypificationId, e.InspectionDocumentId })
                    .HasName("KFIS_TIPIFICACAO_DF");

            builder.ToTable("TFIS_TIPIFICACAO_DF");

            builder.Property(e => e.InsDocTypificationId)
                .HasColumnName("COD_TIPIFICACAO_DF")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.TypificationId)
                .HasColumnName("COD_TIPIFICACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.JsonOutput)
                .HasColumnName("DSC_JSON_OUTPUT")
                .HasColumnType("CLOB")
                .IsUnicode(false);

            builder.Property(e => e.FreeText)
                .IsRequired()
                .HasColumnName("IND_TEXTO_LIVRE")
                .HasDefaultValueSql(@"0");

            builder.HasOne(e => e.Typification)
                .WithMany(p => p.InsDocTypificationList)
                .HasForeignKey(e => e.TypificationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}