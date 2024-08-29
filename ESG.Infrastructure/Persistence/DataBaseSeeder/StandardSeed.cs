using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public class StandardSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Standard>().HasData(new Standard { Id = 1, Code = "ESRS2_GP", ShortText = "General principles", LongText = "General principles", State = StateEnum.active, LanguageId = 1, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 2, Code = "ESRS2_MDR", ShortText = "General disclosures", LongText = "General disclosures", State = StateEnum.active, LanguageId = 1, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 3, Code = "E1", ShortText = "Climate change", LongText = "Climate change", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 4, Code = "E2", ShortText = "Pollution", LongText = "Pollution", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 5, Code = "E3", ShortText = "Water & marine resources", LongText = "Water & marine resources", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 6, Code = "E4", ShortText = "Biodiversity and eco systems", LongText = "Biodiversity and eco systems", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 7, Code = "E5", ShortText = "Resourtce use and circular economy", LongText = "Resourtce use and circular economy", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 8, Code = "S1", ShortText = "Own workforce", LongText = "Own workforce", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 9, Code = "S2", ShortText = "Workers in value chain", LongText = "Workers in value chain", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 10, Code = "S3", ShortText = "Affected communities", LongText = "Affected communities", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 11, Code = "S4", ShortText = "Consumers and end-users", LongText = "Consumers and end-users", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 12, Code = "G1", ShortText = "Business Conduct", LongText = "Business Conduct", State = StateEnum.active, LanguageId = 1, TopicId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
        }
    }
}
