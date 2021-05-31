using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class NrUfConfiguration : IEntityTypeConfiguration<NrUf>
    {
        public void Configure(EntityTypeBuilder<NrUf> builder)
        {
            builder.HasKey(e => e.NrUfId)
                    .HasName("KFIS_NRUF");

            builder.ToTable("TFIS_NRUF");

            builder.Property(e => e.NrUfId)
                .HasColumnName("COD_NRUF")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.PlanningEmail)
                    .HasColumnName("DSC_EMAIL_PLANEJAMENTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.ResultEmail)
                .HasColumnName("DSC_EMAIL_RESULTADO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasColumnName("DSC_ENDERECO")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Name)
               .HasColumnName("NOM_NRUF")
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.Responsible)
                .HasColumnName("NOM_RESPONSAVEL")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.SubstituteResponsible)
                .HasColumnName("NOM_RESPONSAVEL_SUBSTITUTO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Acronym)
               .HasColumnName("SIG_NRUF")
               .HasMaxLength(10)
               .IsUnicode(false);
        }
    }
}