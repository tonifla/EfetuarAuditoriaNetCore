using AppFiscDf.Domain.Entities;
using AppFiscDf.Infra.Data.EntitieConfiguration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InspectionDocumentConfiguration : IEntityTypeConfiguration<InspectionDocument>
    {
        public void Configure(EntityTypeBuilder<InspectionDocument> builder)
        {
            builder.HasKey(e => e.InspectionDocumentId)
                    .HasName("KFIS_DOCUMENTO_FISCALIZACAO");

            builder.ToTable("TFIS_DOCUMENTO_FISCALIZACAO");

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasValueGenerator((_, __) => new SequenceValueGenerator("SFIS_DOCUMENTO_FISCALIZACAO"));

            builder.HasIndex(e => e.SequentialCode)
                    .IsUnique();

            builder.Property(e => e.SequentialCode)
                .HasColumnName("COD_SEQUENCIAL")
                .HasColumnType("NUMBER");

            builder.Property(e => e.JudgmentSectorId)
                .HasColumnName("COD_SETOR_JULGAMENTO_PROCESSO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.UfReference)
                .HasColumnName("COD_REFERENCIA_UF")
                .HasColumnType("NUMBER");

            builder.Property(e => e.UpdateDate)
                .HasColumnName("DHA_ALTERADO")
                .HasColumnType("DATE")
                .HasDefaultValueSql("SYSDATE");

            builder.Property(e => e.EndDate)
                .HasColumnName("DHA_FINALIZADO")
                .HasColumnType("DATE");

            builder.Property(e => e.StartDate)
                .HasColumnName("DHA_INICIADO")
                .HasColumnType("DATE")
                .HasDefaultValueSql("SYSDATE");

            builder.Property(e => e.Finished)
                .HasColumnName("IND_FINALIZADO");

            builder.Property(e => e.DocumentNumber)
                .HasColumnName("NUM_DF")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Latitude)
                .HasColumnName("NUM_LATITUDE")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Longitude)
                .HasColumnName("NUM_LONGITUDE")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(e => e.InsDocEconomicAgent)
                .WithOne()
                .HasForeignKey<InsDocEconomicAgent>(e => e.InspectionDocumentId);

            builder.HasOne(e => e.Sequential)
                .WithMany(p => p.InspectionDocumentList)
                .HasForeignKey(e => e.SequentialCode)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Uf)
                .WithMany(p => p.InspectionDocumentList)
                .HasForeignKey(e => e.UfReference)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.InsDocSerialized)
                .WithOne()
                .HasForeignKey<InsDocSerialized>(e => e.InspectionDocumentId);

            builder.HasOne(e => e.InsDocRepresentative)
                .WithOne()
                .HasForeignKey<InsDocRepresentative>(e => e.InspectionDocumentId);

            builder.HasOne(e => e.InsDocServiceOrder)
                .WithOne()
                .HasForeignKey<InsDocServiceOrder>(e => e.InspectionDocumentId);

            builder.HasMany(e => e.InsDocWitnessList)
                .WithOne()
                .HasForeignKey(e => e.InspectionDocumentId);

            builder.HasMany(e => e.InsDocTypificationList)
                .WithOne()
                .HasForeignKey(e => e.InspectionDocumentId);

            builder.HasMany(e => e.InsDocAttachmentList)
                .WithOne()
                .HasForeignKey(e => e.InspectionDocumentId);

            builder.HasMany(e => e.InsDocEmailList)
                .WithOne()
                .HasForeignKey(e => e.InspectionDocumentId);
        }
    }
}