using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocEconomicAgentConfiguration : IEntityTypeConfiguration<InsDocEconomicAgent>
    {
        public void Configure(EntityTypeBuilder<InsDocEconomicAgent> builder)
        {
            builder.HasKey(e => e.InspectionDocumentId)
                    .HasName("KFIS_AGENTE_ECONOMICO_DF");

            builder.ToTable("TFIS_AGENTE_ECONOMICO_DF");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.ActivityId)
                .HasColumnName("COD_ATIVIDADE")
                .HasColumnType("NUMBER");

            builder.Property(e => e.UfReference)
                .HasColumnName("COD_REFERENCIA_UF")
                .HasColumnType("NUMBER");

            builder.Property(e => e.PublicationDf)
                .HasColumnName("DHA_PUBLICACAO_DF")
                .HasColumnType("DATE");

            builder.Property(e => e.Block)
                .HasColumnName("DSC_BLOCO_EXPLORATORIO")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.AddressComplement)
                .HasColumnName("DSC_COMPLEMENTO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("DSC_EMAIL")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasColumnName("DSC_ENDERECO")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnName("DSC_NOME")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CompanyName)
                .HasColumnName("DSC_RAZAO_SOCIAL")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.InspectedUnit)
                .HasColumnName("DSC_UNIDADE_FISCALIZADA")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Neighborhood)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AuthorizationNumber)
                .IsRequired()
                .HasColumnName("NUM_AUTORIZACAO")
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(e => e.CellPhone)
                .HasColumnName("NUM_CELULAR")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(e => e.ZipCode)
                .HasColumnName("NUM_CEP")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CpfCnpj)
                .HasColumnName("NUM_CPF_CNPJ")
                .HasMaxLength(18)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .HasColumnName("NUM_TELEFONE")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.HasOne(e => e.Activity)
                .WithMany(p => p.InsDocEconomicAgentList)
                .HasForeignKey(e => e.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Uf)
                .WithMany(p => p.InsDocEconomicAgentList)
                .HasForeignKey(e => e.UfReference)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}