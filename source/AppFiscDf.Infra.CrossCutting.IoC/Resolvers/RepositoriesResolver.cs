using AppFiscDf.Domain.Interface.Repositories;
using AppFiscDf.Domain.Interface.WebServices;
using AppFiscDf.Infra.Data.Repositories;
using AppFiscDf.Infra.WebService;
using Microsoft.Extensions.DependencyInjection;

namespace AppFiscDf.Infra.CrossCutting.IoC.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IEconomicAgentReducedRepository, EconomicAgentReducedRepository>();
            services.AddScoped<IEconomicAgentRepository, EconomicAgentRepository>();
            services.AddScoped<IEmailSga, EmailSga>();
            services.AddScoped<IInspectionAgentRepository, InspectionAgentRepository>();
            services.AddScoped<IInsDocAttachmentRepository, InsDocAttachmentRepository>();
            services.AddScoped<IInsDocEconomicAgentRepository, InsDocEconomicAgentRepository>();
            services.AddScoped<IInsDocInspectionAgentRepository, InsDocInspectionAgentRepository>();
            services.AddScoped<IInspectionDocumentRepository, InspectionDocumentRepository>();
            services.AddScoped<IInsDocRepresentativeRepository, InsDocRepresentativeRepository>();
            services.AddScoped<IInsDocTypificationRepository, InsDocTypificationRepository>();
            services.AddScoped<IInsDocWitnessRepository, InsDocWitnessRepository>();
            services.AddScoped<IJudgmentSectorRepository, JudgmentSectorRepository>();
            services.AddScoped<INrUfRepository, NrUfRepository>();
            services.AddScoped<ISequentialRepository, SequentialRepository>();
            services.AddScoped<IUfRepository, UfRepository>();
            services.AddScoped<IUorgRepository, UorgRepository>();

            return services;
        }
    }
}