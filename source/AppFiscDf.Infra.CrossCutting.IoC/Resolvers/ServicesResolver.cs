using AppFiscDf.Application.Implementation;
using AppFiscDf.Application.Interface;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services;
using AppFiscDf.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace AppFiscDf.Infra.CrossCutting.IoC.Resolvers
{
    public static class ServicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityAppService, ActivityAppService>();

            services.AddScoped<IEconomicAgentReducedService, EconomicAgentReducedService>();
            services.AddScoped<IEconomicAgentReducedAppService, EconomicAgentReducedAppService>();

            services.AddScoped<IEconomicAgentService, EconomicAgentService>();
            services.AddScoped<IEconomicAgentAppService, EconomicAgentAppService>();

            services.AddScoped<IEmailSgaService, EmailSgaService>();
            services.AddScoped<IEmailSgaAppService, EmailSgaAppService>();

            services.AddScoped<IInspectionAgentService, InspectionAgentService>();
            services.AddScoped<IInspectionAgentAppService, InspectionAgentAppService>();

            services.AddScoped<IInsDocAttachmentService, InsDocAttachmentService>();
            services.AddScoped<IInsDocAttachmentAppService, InsDocAttachmentAppService>();

            services.AddScoped<IInspectionDocumentService, InspectionDocumentService>();
            services.AddScoped<IInspectionDocumentAppService, InspectionDocumentAppService>();

            services.AddScoped<IJudgmentSectorService, JudgmentSectorService>();
            services.AddScoped<IJudgmentSectorAppService, JudgmentSectorAppService>();

            services.AddScoped<INrUfService, NrUfService>();
            services.AddScoped<INrUfAppService, NrUfAppService>();

            services.AddScoped<ISequentialService, SequentialService>();
            services.AddScoped<ISequentialAppService, SequentialAppService>();

            services.AddScoped<IUfService, UfService>();
            services.AddScoped<IUfAppService, UfAppService>();

            services.AddScoped<IUorgService, UorgService>();
            services.AddScoped<IUorgAppService, UorgAppService>();

            return services;
        }
    }
}