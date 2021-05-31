using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class JudgmentSectorConfiguration : IEntityTypeConfiguration<JudgmentSector>
    {
        public void Configure(EntityTypeBuilder<JudgmentSector> builder)
        {
            builder.HasKey(e => e.JudgmentSectorId)
                    .HasName("KFIS_SETOR_JULGAMENTO_PROCESSO");

            builder.ToTable("TFIS_SETOR_JULGAMENTO_PROCESSO");

            builder.Property(e => e.JudgmentSectorId)
                .HasColumnName("COD_SETOR_JULGAMENTO_PROCESSO")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("DSC_ENDERECO")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Name)
               .HasColumnName("NOM_SETOR_JULGAMENTO_PROCESSO")
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.Acronym)
                .HasColumnName("SIG_SETOR_JULGAMENTO_PROCESSO")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}