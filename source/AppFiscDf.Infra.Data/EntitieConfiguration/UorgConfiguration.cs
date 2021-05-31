using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class UorgConfiguration : IEntityTypeConfiguration<Uorg>
    {
        public void Configure(EntityTypeBuilder<Uorg> builder)
        {
            builder.HasKey(e => e.UorgId)
                    .HasName("KFIS_UORG");

            builder.ToTable("TFIS_UORG");

            builder.Property(e => e.UorgId)
                .HasColumnName("COD_UORG")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NOM_UORG")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Acronym)
                .HasColumnName("SIG_UORG")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}