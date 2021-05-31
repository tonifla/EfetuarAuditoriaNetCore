using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InspectionProcedureConfiguration : IEntityTypeConfiguration<InspectionProcedure>
    {
        public void Configure(EntityTypeBuilder<InspectionProcedure> builder)
        {
            builder.HasKey(e => e.InspectionProcedureId)
                    .HasName("KFIS_PROCEDIMENTO_FISCALIZACAO");

            builder.ToTable("TFIS_PROCEDIMENTO_FISCALIZACAO");

            builder.Property(e => e.InspectionProcedureId)
                .HasColumnName("COD_PROCEDIMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.UorgId)
                .HasColumnName("COD_UORG")
                .HasColumnType("NUMBER");

            builder.Property(e => e.Text)
                .HasColumnName("DSC_TEXTO")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Sort)
                .HasColumnName("NUM_ORDEM")
                .HasColumnType("NUMBER");

            builder.HasOne(e => e.Uorg)
                .WithMany(p => p.InspectionProcedureList)
                .HasForeignKey(e => e.UorgId);
        }
    }
}