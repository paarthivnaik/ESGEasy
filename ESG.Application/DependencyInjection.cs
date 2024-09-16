using ESG.Application.Common.Interface;
using ESG.Application.Common.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UnitOfMeasureProfile),
                                    typeof(UnitOfMeasureTypeProfile),
                                    typeof(UnitOfMeasureTranslationsProfile),
                                    typeof(UnitOfMeasureTypeTranslationsProfile),
                                    typeof(DimensionsProfile),
                                    typeof(DimensionTypeProfile),
                                    typeof(DimensionTranslationsProfile),
                                    typeof(CurrencyProfile),
                                    typeof(DataPointValuesProfile),
                                    typeof(GetTranslationsProfile),
                                    typeof(HierarchyProfile),
                                    typeof(DisclosureRequirementProfile),
                                    typeof(UserProfile),
                                    typeof(DimensionTypeTranslationsProfile));
            return services;
        }
    }
}
