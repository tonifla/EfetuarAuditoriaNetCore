using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Domain.Interface.WebServices;
using System;
using System.Threading.Tasks;

namespace AppFiscDf.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository ActivityRepository { get; }
        IEconomicAgentReducedRepository EconomicAgentReducedRepository { get; }
        IEconomicAgentRepository EconomicAgentRepository { get; }
        IEmailSga EmailSga { get; }
        IInspectionAgentRepository InspectionAgentRepository { get; }
        IInsDocAttachmentRepository InsDocAttachmentRepository { get; }
        IInsDocEconomicAgentRepository InsDocEconomicAgentRepository { get; }
        IInsDocInspectionAgentRepository InsDocInspectionAgentRepository { get; }
        IInspectionDocumentRepository InspectionDocumentRepository { get; }
        IInsDocRepresentativeRepository InsDocRepresentativeRepository { get; }
        IInsDocTypificationRepository InsDocTypificationRepository { get; }
        IInsDocWitnessRepository InsDocWitnessRepository { get; }
        IInsDocEmailRepository InsDocEmailRepository { get; }
        IInsDocSerializedRepository InsDocSerializedRepository { get; }
        IInsDocServiceOrderRepository InsDocServiceOrderRepository { get; }
        IJudgmentSectorRepository JudgmentSectorRepository { get; }
        INrUfRepository NrUfRepository { get; }
        ISequentialRepository SequentialRepository { get; }
        IUfRepository UfRepository { get; }
        IUorgRepository UorgRepository { get; }

        Task<bool> CompletedAsync();
    }
}