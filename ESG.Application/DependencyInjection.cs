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
                                    typeof(UnitOfMeasureTranslationProfile),
                                    typeof(UnitOfMeasureTypeTranslationsProfile),
                                    typeof(DimensionProfile),
                                    typeof(DimensionTypeProfile),
                                    typeof(DimensionTranslationProfile),
                                    typeof(CurrencyProfile),
                                    typeof(DataPointValueProfile),
                                    typeof(GetTranslationsProfile),
                                    typeof(HierarchyProfile),
                                    typeof(DisclosureRequirementProfile),
                                    typeof(UserProfile),
                                    typeof(DimensionTypeTranslationProfile),
                                    typeof(LanguageProfile));
            return services;
        }
    }
}
