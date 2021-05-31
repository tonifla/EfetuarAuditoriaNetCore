using AppFiscDf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFiscDf.Infra.Data.EntitieConfiguration
{
    public class InsDocAttachmentConfiguration : IEntityTypeConfiguration<InsDocAttachment>
    {
        public void Configure(EntityTypeBuilder<InsDocAttachment> builder)
        {
            builder.HasKey(e => new { e.InsDocAttachmentId, e.InspectionDocumentId })
                     .HasName("KFIS_ANEXO_DF");

            builder.ToTable("TFIS_ANEXO_DF");

            builder.Property(e => e.InsDocAttachmentId)
                .HasColumnName("COD_ANEXO_DF")
                .HasColumnType("NUMBER")
                .IsRequired();

            builder.Property(e => e.InspectionDocumentId)
                .HasColumnName("SEQ_DOCUMENTO_FISCALIZACAO")
                .HasColumnType("NUMBER");

            builder.Property(e => e.AttachmentDate)
                .HasColumnName("DHA_ANEXO")
                .HasColumnType("DATE")
                .HasDefaultValueSql("SYSDATE");

            builder.Property(e => e.Name)
                .HasColumnName("NOM_ANEXO")
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.AttachmentFile)
                .HasColumnName("OBJ_ANEXO")
                .HasColumnType("BLOB");
        }
    }
}