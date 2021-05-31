using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class EconomicAgentConfiguration : IEntityTypeConfiguration<EconomicAgent>
    {
        public void Configure(EntityTypeBuilder<EconomicAgent> builder)
        {
            builder.HasKey(e => e.EconomicAgentId)
                    .HasName("KFIS_AGENTE_ECONOMICO");

            builder.ToTable("TFIS_AGENTE_ECONOMICO");

            builder.Property(e => e.EconomicAgentId)
                .HasColumnName("COD_INSTALACAO")
                .HasMaxLength(18)
                .IsUnicode(false);

            builder.Property(e => e.EffectiveEndDate)
                .HasColumnName("DAT_MESANO_VIGENCIA_FINAL")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.EffectiveStartDate)
                .HasColumnName("DAT_MESANO_VIGENCIA_INICIAL")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.PublicationDate)
                .HasColumnName("DAT_PUBLICACAO")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Neighborhood)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(64)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .HasColumnName("NOM_ESTADO")
                .HasMaxLength(19)
                .IsUnicode(false);

            builder.Property(e => e.District)
                .HasColumnName("NOM_MUNICIPIO")
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.Company)
                .HasColumnName("NOM_RAZAO_SOCIAL")
                .HasMaxLength(192)
                .IsUnicode(false);

            builder.Property(e => e.ReducedCompany)
                .HasColumnName("NOM_REDUZIDO")
                .HasMaxLength(96)
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .HasColumnName("NOM_TITULO")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.AuthorizationNumber)
                .HasColumnName("NUM_AUTORIZACAO")
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(e => e.ZipCode)
                .HasColumnName("NUM_CEP")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.AdministratorCnpj)
                .HasColumnName("NUM_CNPJ_ADMINISTRADOR_BASE")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.InstallationCnpj)
                .HasColumnName("NUM_CNPJ_INSTALACAO")
                .HasMaxLength(18)
                .IsUnicode(false);

            builder.Property(e => e.Number)
                .HasColumnName("NUM_NUMERO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Complement)
                .HasColumnName("TXT_COMPLEMENTO")
                .HasMaxLength(64)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasColumnName("TXT_ENDERECO")
                .HasMaxLength(192)
                .IsUnicode(false);

            builder.Property(e => e.InstallationIdentification)
                .HasColumnName("TXT_IDENTIFICACAO_INSTALACAO")
                .HasMaxLength(64)
                .IsUnicode(false);

            builder.Property(e => e.Status)
                .HasColumnName("TXT_STATUS")
                .HasMaxLength(16)
                .IsUnicode(false);

            builder.Property(e => e.InstallationType)
                .HasColumnName("TXT_TIPO_INSTALACAO")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.UfAcronym)
                .HasColumnName("COD_UF")
                .HasMaxLength(2)
                .IsUnicode(false);
        }
    }
}