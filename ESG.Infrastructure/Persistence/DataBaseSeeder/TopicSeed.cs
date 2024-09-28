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
                new Topic { Id = 2, Code = "environment", ShortText = "Environment", LongText = "Environment", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 3, Code = "social", ShortText = "Social", LongText = "Social", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Topic { Id = 4, Code = "governance", ShortText = "Governance", LongText = "Governance", State = StateEnum.active, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
        }
    }
}
