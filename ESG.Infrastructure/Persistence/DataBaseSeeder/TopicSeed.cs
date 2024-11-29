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
                new Topic { Id = 17, Code = "general", ShortText = "Algemeen", LongText = "Algemeen", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 18, Code = "environment", ShortText = "M-Milieu", LongText = "M-Milieu", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 19, Code = "social", ShortText = "S-Sociaal", LongText = "S-Sociaal", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 20, Code = "governance", ShortText = "B-Bestuur", LongText = "B-Bestuur", State = StateEnum.active, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                );
        }
    }
}
