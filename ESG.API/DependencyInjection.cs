using ESG.Application.Common.Interface.Tenants;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Infrastructure.Persistence.UnitOfMeasureRepo;

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
            services.AddScoped<IDatapointValuesService, DatapointValuesService>();
            services.AddScoped<IDimensionsService, DimensionsService>();
            services.AddScoped<IUnitOfMeasureRepo, UnitOfMeasureRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUOMTranslationsService, UOMTranslationService>();
            services.AddScoped<IUOMTypeTranslationsService, UOMTypeTranslationsService>();
            services.AddScoped<IValuesService, ValuesService>();
            services.AddScoped<IHierarchyService, HierarchyService>();
            services.AddScoped<IDataModelService, DataModelService>();
            return services;
        }
    }
}
