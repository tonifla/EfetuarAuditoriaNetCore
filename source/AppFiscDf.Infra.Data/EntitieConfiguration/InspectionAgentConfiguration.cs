using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InspectionAgentConfiguration : IEntityTypeConfiguration<InspectionAgent>
    {
        public void Configure(EntityTypeBuilder<InspectionAgent> builder)
        {
            builder.HasKey(e => e.InspectionAgentId)
                    .HasName("KFIS_AGENTE_FISCALIZACAO");

            builder.ToTable("TFIS_AGENTE_FISCALIZACAO");

            builder.Property(e => e.InspectionAgentId)
                .HasColumnName("COD_AGENTE_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.NrUfId)
                .HasColumnName("COD_NRUF")
                .HasColumnType("NUMBER");

            builder.Property(e => e.SignatureDate)
                .HasColumnName("DHA_ASSINATURA")
                .HasColumnType("DATE");

            builder.Property(e => e.OrganOfOrigin)
                .HasColumnName("DSC_CARGO")
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.Employment)
                .HasColumnName("DSC_ORGAO")
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                    .HasColumnName("DSC_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Login)
                .HasColumnName("DSC_LOGIN")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.SignatureImage)
                .HasColumnName("IMG_ASSINATURA")
                .HasColumnType("BLOB");

            builder.Property(e => e.Name)
                .HasColumnName("NOM_AGENTE_FISCALIZACAO")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Cpf)
                .HasColumnName("NUM_CPF")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(e => e.Registry)
                .HasColumnName("NUM_MATRICULA")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Status)
               .HasColumnName("IND_ATIVO");

            builder.HasOne(e => e.NrUf)
                    .WithMany(p => p.InspectionAgentList)
                    .HasForeignKey(e => e.NrUfId);
        }
    }
}