using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class UfConfiguration : IEntityTypeConfiguration<Uf>
    {
        public void Configure(EntityTypeBuilder<Uf> builder)
        {
            builder.HasKey(e => e.UfReference)
                    .HasName("KFIS_UF");

            builder.ToTable("TFIS_UF");

            builder.Property(e => e.UfReference)
                .HasColumnName("COD_REFERENCIA_UF")
                .HasColumnType("NUMBER")
                .IsUnicode(false);

            builder.Property(e => e.UfAcronym)
                .HasColumnName("COD_UF")
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(e => e.NrUfId)
                .HasColumnName("COD_NRUF")
                .HasColumnType("NUMBER");

            builder.Property(e => e.Name)
                .HasColumnName("NOM_UF")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(e => e.NrUf)
                .WithMany(p => p.UfList)
                .HasForeignKey(e => e.NrUfId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}