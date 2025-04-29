using ESG.Domain.Models;
using ESG.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public class TopicSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Topic>().HasData(new Topic { Id = 1, Code = "general", ShortText = "General", LongText = "General", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 2, Code = "environment", ShortText = "E-Environment", LongText = "E-Environment", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 3, Code = "social", ShortText = "S-Social", LongText = "S-Social", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 4, Code = "governance", ShortText = "G-Governance", LongText = "G-Governance", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 5, Code = "VSME", ShortText = "VSME", LongText="VSME", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow,LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            );
            
            modelBuilder.Entity<TopicTranslation>().HasData(
                new TopicTranslation { Id = 1, TopicId = 1, ShortText = "General", LongText = "General", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 2, TopicId = 2, ShortText = "E - Environment", LongText = "E - Environment", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 3, TopicId = 3, ShortText = "S - Social", LongText = "S - Social", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 4, TopicId = 4, ShortText = "G - Governance", LongText = "G - Governance", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 5, TopicId = 5, ShortText = "VSME", LongText = "VSME", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 6, TopicId = 1, ShortText = "Généralités", LongText = "Généralités", State = StateEnum.active, LanguageId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 7, TopicId = 2, ShortText = "E - Environnement", LongText = "E - Environnement", State = StateEnum.active, LanguageId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 8, TopicId = 3, ShortText = "S - Social", LongText = "S - Social", State = StateEnum.active, LanguageId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 9, TopicId = 4, ShortText = "G - Gouvernance", LongText = "G - Gouvernance", State = StateEnum.active, LanguageId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 10, TopicId = 5, ShortText = "VSME", LongText = "VSME", State = StateEnum.active, LanguageId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 11, TopicId = 1, ShortText = "General", LongText = "General", State = StateEnum.active, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 12, TopicId = 2, ShortText = "M - Medio ambiente", LongText = "M - Medio ambiente", State = StateEnum.active, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 13, TopicId = 3, ShortText = "S - Social", LongText = "S - Social", State = StateEnum.active, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 14, TopicId = 4, ShortText = "G - Gobernanza", LongText = "G - Gobernanza", State = StateEnum.active, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 15, TopicId = 5, ShortText = "VSME", LongText = "VSME", State = StateEnum.active, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 16, TopicId = 1, ShortText = "Allgemein", LongText = "Allgemein", State = StateEnum.active, LanguageId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 17, TopicId = 2, ShortText = "U - Umwelt", LongText = "U - Umwelt", State = StateEnum.active, LanguageId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 18, TopicId = 3, ShortText = "S - Soziales", LongText = "S - Soziales", State = StateEnum.active, LanguageId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 19, TopicId = 4, ShortText = "G - Governance", LongText = "G - Governance", State = StateEnum.active, LanguageId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 20, TopicId = 5, ShortText = "VSME", LongText = "VSME", State = StateEnum.active, LanguageId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 21, TopicId = 1, ShortText = "Algemeen", LongText = "Algemeen", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 22, TopicId = 2, ShortText = "M - Milieu", LongText = "M - Milieu", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 23, TopicId = 3, ShortText = "S - Sociaal", LongText = "S - Sociaal", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 24, TopicId = 4, ShortText = "B - Bestuur", LongText = "B - Bestuur", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new TopicTranslation { Id = 25, TopicId = 5, ShortText = "VSME", LongText = "VSME", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
            );
        }
    }
}
