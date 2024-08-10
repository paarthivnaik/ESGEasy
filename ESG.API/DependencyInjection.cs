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
            services.AddScoped<IUserRoles, UserRolesServices>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IOrganizationUsersService, OrganizationUsersService>();
            services.AddScoped<IUnitOfMeasureTypeService, UnitOfMeasureTypeService>();
            services.AddScoped<IDimentionTypeService, DimentionTypeService>();
            services.AddScoped<IDimensionsService, DimensionsService>();
            services.AddScoped<IDatapointTypesService, DatapointTypesService>();
            services.AddScoped<IDimensionsService, DimensionsService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
