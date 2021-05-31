using AppFiscDf.Domain.Entities;
using AppFiscDf.Infra.Data.EntitieConfiguration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocEmailConfiguration : IEntityTypeConfiguration<InsDocEmail>
    {
        public void Configure(EntityTypeBuilder<InsDocEmail> builder)
        {
            builder.HasKey(e => e.InsDocEmailId)
                    .HasName("KFIS_EMAIL_DF");

            builder.ToTable("TFIS_EMAIL_DF");

            builder.Property(e => e.InsDocEmailId)
                .HasColumnName("SEQ_EMAIL_DF")
                .HasColumnType("NUMBER")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasValueGenerator((_, __) => new SequenceValueGenerator("SFIS_EMAIL_DF"));

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .IsRequired()
                .HasColumnType("NUMBER");

            builder.Property(e => e.Sender)
               .HasColumnName("DSC_REMETENTE")
               .HasMaxLength(200)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.Recipients)
                .HasColumnName("DSC_DESTINATARIOS")
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Subject)
                .HasColumnName("DSC_TITULO_EMAIL")
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Content)
               .HasColumnName("DSC_CORPO_EMAIL")
               .HasMaxLength(4000)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(e => e.TypeMessage)
              .HasColumnName("IND_TIPO_MENSAGEM")
              .IsRequired();
        }
    }
}