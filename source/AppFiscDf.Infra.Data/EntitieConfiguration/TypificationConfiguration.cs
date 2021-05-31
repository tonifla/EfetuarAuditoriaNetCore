using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class TypificationConfiguration : IEntityTypeConfiguration<Typification>
    {
        public void Configure(EntityTypeBuilder<Typification> builder)
        {
            builder.HasKey(e => e.TypificationId)
                    .HasName("KFIS_TIPIFICACAO");

            builder.ToTable("TFIS_TIPIFICACAO");

            builder.Property(e => e.TypificationId)
                .HasColumnName("COD_TIPIFICACAO")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.ActivityId)
                .HasColumnName("COD_ATIVIDADE")
                .HasColumnType("NUMBER");

            builder.Property(e => e.InspectionProcedureId)
                .HasColumnName("COD_PROCEDIMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.HTMLInput)
                .HasColumnName("DSC_HTML_INPUT")
                .HasColumnType("CLOB")
                .IsUnicode(false);

            builder.Property(e => e.JsonInput)
                .HasColumnName("DSC_JSON_INPUT")
                .IsUnicode(false);

            builder.Property(e => e.Model)
                .HasColumnName("NOM_MODELO")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .HasColumnName("NOM_TITULO")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(e => e.Activity)
                .WithMany(p => p.TypificationList)
                .HasForeignKey(e => e.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.InspectionProcedure)
                .WithMany(p => p.TypificationList)
                .HasForeignKey(e => e.InspectionProcedureId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}