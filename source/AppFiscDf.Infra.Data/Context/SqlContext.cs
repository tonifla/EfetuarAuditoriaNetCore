using AppFiscDf.Domain.Entities;
using AppFiscDf.Infra.Data.EntitieConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AppFiscDf.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<EconomicAgent> EconomicAgent { get; set; }
        public virtual DbSet<EconomicAgentReduced> EconomicAgentReduced { get; set; }
        public virtual DbSet<InspectionAgent> InspectionAgent { get; set; }
        public virtual DbSet<InspectionDocument> InspectionDocument { get; set; }
        public virtual DbSet<InsDocEmail> InsDocEmail { get; set; }
        public virtual DbSet<InsDocAttachment> InsDocAttachment { get; set; }
        public virtual DbSet<InsDocInspectionAgent> InsDocInspectionAgent { get; set; }
        public virtual DbSet<InsDocEconomicAgent> InsDocEconomicAgent { get; set; }
        public virtual DbSet<InsDocRepresentative> InsDocRepresentative { get; set; }
        public virtual DbSet<InsDocTypification> InsDocTypification { get; set; }
        public virtual DbSet<InsDocWitness> InsDocWitness { get; set; }
        public virtual DbSet<InspectionProcedure> InspectionProcedure { get; set; }
        public virtual DbSet<JudgmentSector> JudgmentSector { get; set; }
        public virtual DbSet<InsDocSerialized> InsDocSerialized { get; set; }
        public virtual DbSet<InsDocServiceOrder> InsDocServiceOrder { get; set; }
        public virtual DbSet<NrUf> NrUf { get; set; }
        public virtual DbSet<Sequential> Sequential { get; set; }
        public virtual DbSet<Typification> Typification { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }
        public virtual DbSet<Uorg> Uorg { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());

            modelBuilder.ApplyConfiguration(new EconomicAgentConfiguration());

            modelBuilder.ApplyConfiguration(new EconomicAgentReducedConfiguration());

            modelBuilder.ApplyConfiguration(new InspectionAgentConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocAttachmentConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocInspectionAgentConfiguration());

            modelBuilder.HasSequence("SFIS_DOCUMENTO_FISCALIZACAO");
            modelBuilder.ApplyConfiguration(new InspectionDocumentConfiguration());

            modelBuilder.HasSequence("SFIS_EMAIL_DF");
            modelBuilder.ApplyConfiguration(new InsDocEmailConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocEconomicAgentConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocRepresentativeConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocTypificationConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocWitnessConfiguration());

            modelBuilder.ApplyConfiguration(new InspectionProcedureConfiguration());

            modelBuilder.ApplyConfiguration(new JudgmentSectorConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocSerializedConfiguration());

            modelBuilder.ApplyConfiguration(new InsDocServiceOrderConfiguration());

            modelBuilder.ApplyConfiguration(new NrUfConfiguration());

            modelBuilder.ApplyConfiguration(new SequentialConfiguration());

            modelBuilder.ApplyConfiguration(new TypificationConfiguration());

            modelBuilder.ApplyConfiguration(new UfConfiguration());

            modelBuilder.ApplyConfiguration(new UorgConfiguration());
        }
    }
}