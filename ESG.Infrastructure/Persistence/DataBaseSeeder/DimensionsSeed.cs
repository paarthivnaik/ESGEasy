using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class DimensionsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimensionType>().HasData(
                new DimensionType { Id = 1, Code = "yyyy", ShortText = "Year", LongText = "Year", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 2, Code = "m", ShortText = "Month", LongText = "Month", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 3, Code = "q", ShortText = "Quarter", LongText = "Quarter", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 4, Code = "d", ShortText = "Day", LongText = "Day", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 5, Code = "vatyp", ShortText = "Value Type", LongText = "Value Type", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 6, Code = "cntry", ShortText = "Country", LongText = "Country", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 7, Code = "city", ShortText = "City", LongText = "City", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 8, Code = "rgn", ShortText = "Region", LongText = "Region", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 9, Code = "sdg", ShortText = "SDG", LongText = "Sustainable Development", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 10, Code = "liro", ShortText = "Line Of Reporting", LongText = "Line Of Reporting", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 11, Code = "domn", ShortText = "Domain", LongText = "Domain", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 12, Code = "bsnss", ShortText = "Business", LongText = "Business", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 13, Code = "mrkt", ShortText = "Market", LongText = "Market", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new DimensionType { Id = 14, Code = "factory", ShortText = "Factory", LongText = "Factory", State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Dimensions>().HasData(
                new Dimensions { Id = 1000, Code = "act", ShortText = "Actual", LongText = "Actual", DimensionTypeId = 5, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1001, Code = "base", ShortText = "Baseline", LongText = "Baseline", DimensionTypeId = 5, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1002, Code = "target", ShortText = "Target", LongText = "Target", DimensionTypeId = 5, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1003, Code = "de", ShortText = "DE", LongText = "Germany", DimensionTypeId = 6, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1004, Code = "nl", ShortText = "NL", LongText = "The Netherlands", DimensionTypeId = 6, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1005, Code = "dap", ShortText = "DAP", LongText = "Domestic Appliances", DimensionTypeId = 12, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1006, Code = "pms", ShortText = "PMS", LongText = "Medical systems", DimensionTypeId = 12, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1007, Code = "eur", ShortText = "EUR", LongText = "Europe", DimensionTypeId = 13, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1008, Code = "ame", ShortText = "AME", LongText = "Africa, Middle East", DimensionTypeId = 13, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1009, Code = "tern", ShortText = "Terneuzen", LongText = "Terneuzen", DimensionTypeId = 14, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1010, Code = "2023", ShortText = "2023", LongText = "2023", DimensionTypeId = 1, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1011, Code = "2024", ShortText = "2024", LongText = "2024", DimensionTypeId = 1, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Dimensions { Id = 1012, Code = "2025", ShortText = "2025", LongText = "2025", DimensionTypeId = 1, State = StateEnum.active, OrganizationId = 1, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }

            );
        }
    }
}
