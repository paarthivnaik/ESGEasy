using ESG.Application.Common.Interface.Account;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Tenants;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Infrastructure.Persistence.AccountsRepo;
using ESG.Infrastructure.Persistence;
using ESG.Infrastructure.Persistence.UnitOfMeasureRepo;
using Microsoft.Extensions.Configuration;
using ESG.Infrastructure.Persistence.DatapointRepo;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Common.Interface.FileUpload;

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
            services.AddScoped<IDimensionService, DimensionService>();
            services.AddScoped<IDatapointTypesService, DataPointTypeService>();
            services.AddScoped<IDataPointValueService, DataPointValueService>();
            services.AddScoped<IDimensionService, DimensionService>();
            services.AddScoped<IUnitOfMeasureRepo, UnitOfMeasureRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUOMTranslationsService, UOMTranslationService>();
            services.AddScoped<IUOMTypeTranslationsService, UOMTypeTranslationsService>();
            services.AddScoped<IValuesService, ValuesService>();
            services.AddScoped<IHierarchyService, HierarchyService>();
            services.AddScoped<IDataModelService, DataModelService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDisclosureRequirementService, DisclosureRequirementService>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IDatapointValueRepo, DatapointValueRepo>();
            return services;
        }
    }
}
