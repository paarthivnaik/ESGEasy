using ESG.Application.Services;
using ESG.Application.Services.Interfaces;

namespace ESG.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIDependancies(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
            return services;
        }
    }
}
