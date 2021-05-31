using AppFiscDf.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppFiscDf.Infra.CrossCutting.IoC.Resolvers
{
    public static class ContextResolver
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SqlContext>(options =>
                options.UseOracle(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<SqlContext, SqlContext>();

            services.AddSingleton<IConfiguration>(configuration);

            return services;
        }
    }
}