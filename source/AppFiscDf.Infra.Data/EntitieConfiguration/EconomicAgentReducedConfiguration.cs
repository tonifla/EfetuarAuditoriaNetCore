using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class EconomicAgentReducedConfiguration : IEntityTypeConfiguration<EconomicAgentReduced>
    {
        public void Configure(EntityTypeBuilder<EconomicAgentReduced> builder)
        {
            builder.HasKey(e => e.EconomicAgentReducedId)
                    .HasName("KFIS_AGENTE_ECONOMICO_REDUZIDO");

            builder.ToTable("TFIS_AGENTE_ECONOMICO_REDUZIDO");

            builder.Property(e => e.EconomicAgentReducedId)
                .HasColumnName("COD_INSTALACAO")
                .HasMaxLength(18)
                .IsUnicode(false);

            builder.Property(e => e.UfAcronym)
                .HasColumnName("COD_UF")
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(e => e.District)
                .HasColumnName("NOM_MUNICIPIO")
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.Company)
                .HasColumnName("NOM_RAZAO_SOCIAL")
                .HasMaxLength(192)
                .IsUnicode(false);

            builder.Property(e => e.InstallationCnpj)
                .HasColumnName("NUM_CNPJ_INSTALACAO")
                .HasMaxLength(18)
                .IsUnicode(false);
        }
    }
}