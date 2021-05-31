using AppFiscDf.Infra.CrossCutting.IoC.Resolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppFiscDf.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static IServiceCollection ResolveApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureContext(configuration)
                    .ConfigureContextAccessor()
                    .ConfigureServices()
                    .ConfigureRepositories()
                    .ConfigureAutoMapper();

            return services;
        }
    }
}