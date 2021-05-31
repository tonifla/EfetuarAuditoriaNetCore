using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Interface.WebServices;
using AppFiscDf.Infra.Data.Context;
using AppFiscDf.Infra.Data.Repositories;
using AppFiscDf.Infra.WebService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AppFiscDf.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        public readonly IConfiguration _configuration;
        private IActivityRepository _activityRepository;
        private IEconomicAgentReducedRepository _economicAgentReducedRepository;
        private IEconomicAgentRepository _economicAgentRepository;
        private IEmailSga _emailSga;
        private IInspectionAgentRepository _inspectionAgentRepository;
        private IInsDocAttachmentRepository _inspDocAttachmentRepository;
        private IInsDocEconomicAgentRepository _insDocEconomicAgentRepository;
        private IInsDocInspectionAgentRepository _insDocInspectionAgentRepository;
        private IInspectionDocumentRepository _inspectionDocumentRepository;
        private IInsDocRepresentativeRepository _insDocRepresentativeRepository;
        private IInsDocTypificationRepository _insDocTypificationRepository;
        private IInsDocWitnessRepository _insDocWitnessRepository;
        private IInsDocEmailRepository _insDocEmailRepository;
        private IInsDocSerializedRepository _insDocSerializedRepository;
        private IInsDocServiceOrderRepository _insDocServiceOrderRepository;
        private IJudgmentSectorRepository _judgmentSectorRepository;
        private INrUfRepository _nrUfRepository;
        private ISequentialRepository _sequentialRepository;
        private IUfRepository _ufRepository;
        private IUorgRepository _uorgRepository;

        public UnitOfWork(SqlContext sqlContext, IConfiguration configuration)
        {
            _sqlContext = sqlContext;
            _configuration = configuration;
        }

        public IActivityRepository ActivityRepository =>
            _activityRepository ??= new ActivityRepository(_sqlContext);

        public IEconomicAgentReducedRepository EconomicAgentReducedRepository =>
            _economicAgentReducedRepository ??= new EconomicAgentReducedRepository(_sqlContext);

        public IEconomicAgentRepository EconomicAgentRepository =>
            _economicAgentRepository ??= new EconomicAgentRepository(_sqlContext);

        public IInsDocEmailRepository InsDocEmailRepository =>
           _insDocEmailRepository ??= new InsDocEmailRepository(_sqlContext);

        public IEmailSga EmailSga =>
          _emailSga ??= new EmailSga(_configuration, InsDocEmailRepository);

        public IInspectionAgentRepository InspectionAgentRepository =>
            _inspectionAgentRepository ??= new InspectionAgentRepository(_sqlContext);

        public IInsDocAttachmentRepository InsDocAttachmentRepository =>
            _inspDocAttachmentRepository ??= new InsDocAttachmentRepository(_sqlContext);

        public IInsDocEconomicAgentRepository InsDocEconomicAgentRepository =>
            _insDocEconomicAgentRepository ??= new InsDocEconomicAgentRepository(_sqlContext);

        public IInsDocInspectionAgentRepository InsDocInspectionAgentRepository =>
            _insDocInspectionAgentRepository ??= new InsDocInspectionAgentRepository(_sqlContext);

        public IInspectionDocumentRepository InspectionDocumentRepository =>
            _inspectionDocumentRepository ??= new InspectionDocumentRepository(_sqlContext);

        public IInsDocRepresentativeRepository InsDocRepresentativeRepository =>
            _insDocRepresentativeRepository ??= new InsDocRepresentativeRepository(_sqlContext);

        public IInsDocTypificationRepository InsDocTypificationRepository =>
            _insDocTypificationRepository ??= new InsDocTypificationRepository(_sqlContext);

        public IInsDocWitnessRepository InsDocWitnessRepository =>
            _insDocWitnessRepository ??= new InsDocWitnessRepository(_sqlContext);

        public IInsDocSerializedRepository InsDocSerializedRepository =>
            _insDocSerializedRepository ??= new InsDocSerializedRepository(_sqlContext);

        public IInsDocServiceOrderRepository InsDocServiceOrderRepository =>
            _insDocServiceOrderRepository ??= new InsDocServiceOrderRepository(_sqlContext);

        public IJudgmentSectorRepository JudgmentSectorRepository =>
            _judgmentSectorRepository ??= new JudgmentSectorRepository(_sqlContext);

        public INrUfRepository NrUfRepository =>
            _nrUfRepository ??= new NrUfRepository(_sqlContext);

        public ISequentialRepository SequentialRepository =>
            _sequentialRepository ??= new SequentialRepository(_sqlContext);

        public IUfRepository UfRepository =>
            _ufRepository ??= new UfRepository(_sqlContext);

        public IUorgRepository UorgRepository =>
            _uorgRepository ??= new UorgRepository(_sqlContext);

        public async Task<bool> CompletedAsync()
        {
            bool returnValue = true;

            var strategy = _sqlContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _sqlContext.Database.BeginTransaction();
                try
                {
                    await _sqlContext.SaveChangesAsync().ConfigureAwait(false);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    //criar logs aqui
                    returnValue = false;
                    transaction.Rollback();
                    throw;
                }
            });

            return returnValue;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _sqlContext.Dispose();
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}