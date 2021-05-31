using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.ActivityId)
                    .HasName("KFIS_ATIVIDADE");

            builder.ToTable("TFIS_ATIVIDADE");

            builder.Property(e => e.ActivityId)
                .HasColumnName("COD_ATIVIDADE")
                .HasColumnType("NUMBER");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("NOM_ATIVIDADE")
                .HasMaxLength(80)
                .IsUnicode(false);
        }
    }
}