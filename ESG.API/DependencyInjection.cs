using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Services;

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
