using ESG.Application.Common.Interface.Tenants;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;

namespace ESG.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIDependancies(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
