using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AppFiscDf.Infra.CrossCutting.IoC.Resolvers
{
    public static class AutoMapperResolver
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperResolver));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Domain.Services.AutoMapper.MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}