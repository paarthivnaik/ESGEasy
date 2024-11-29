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
    public class StandardSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Standard>().HasData(
                // English Entries (LanguageId = 1)
                new Standard { Id = 1, Code = "ESRS2_GP", ShortText = "ESRS2_GP - General principles", LongText = "ESRS2_GP - General principles", State = StateEnum.active, LanguageId = 1, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 2, Code = "ESRS2_MDR", ShortText = "ESRS2_MDR - General disclosures", LongText = "ESRS2_MDR - General disclosures", State = StateEnum.active, LanguageId = 1, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 3, Code = "E1", ShortText = "E1 - Climate change", LongText = "E1 - Climate change", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 4, Code = "E2", ShortText = "E2 - Pollution", LongText = "E2 - Pollution", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 5, Code = "E3", ShortText = "E3 - Water and marine resources", LongText = "E3 - Water and marine resources", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 6, Code = "E4", ShortText = "E4 - Biodiversity and ecosystems", LongText = "E4 - Biodiversity and ecosystems", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 7, Code = "E5", ShortText = "E5 - Resource use and circular economy", LongText = "E5 - Resource use and circular economy", State = StateEnum.active, LanguageId = 1, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 8, Code = "S1", ShortText = "S1 - Own workforce", LongText = "S1 - Own workforce", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 9, Code = "S2", ShortText = "S2 - Workers in the value chain", LongText = "S2 - Workers in the value chain", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 10, Code = "S3", ShortText = "S3 - Affected communities", LongText = "S3 - Affected communities", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 11, Code = "S4", ShortText = "S4 - Consumers and end-users", LongText = "S4 - Consumers and end-users", State = StateEnum.active, LanguageId = 1, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 12, Code = "G1", ShortText = "G1 - Governance, risk, and internal control", LongText = "G1 - Governance, risk, and internal control", State = StateEnum.active, LanguageId = 1, TopicId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },

                // French Entries (LanguageId = 2)
                new Standard { Id = 13, Code = "ESRS2_GP", ShortText = "ESRS2_GP - Principes généraux", LongText = "ESRS2_GP - Principes généraux", State = StateEnum.active, LanguageId = 2, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 14, Code = "ESRS2_MDR", ShortText = "ESRS2_MDR - Informations générales", LongText = "ESRS2_MDR - Informations générales", State = StateEnum.active, LanguageId = 2, TopicId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 15, Code = "E1", ShortText = "E1 - Changement climatique", LongText = "E1 - Changement climatique", State = StateEnum.active, LanguageId = 2, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 16, Code = "E2", ShortText = "E2 - Pollution", LongText = "E2 - Pollution", State = StateEnum.active, LanguageId = 2, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 17, Code = "E3", ShortText = "E3 - Ressources marines et aquatiques", LongText = "E3 - Ressources marines et aquatiques", State = StateEnum.active, LanguageId = 2, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 18, Code = "E4", ShortText = "E4 - Biodiversité et écosystèmes", LongText = "E4 - Biodiversité et écosystèmes", State = StateEnum.active, LanguageId = 2, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 19, Code = "E5", ShortText = "E5 - Utilisation des ressources et économie circulaire", LongText = "E5 - Utilisation des ressources et économie circulaire", State = StateEnum.active, LanguageId = 2, TopicId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 20, Code = "S1", ShortText = "S1 - Main-d'œuvre propre", LongText = "S1 - Main-d'œuvre propre", State = StateEnum.active, LanguageId = 2, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 21, Code = "S2", ShortText = "S2 - Travailleurs de la chaîne de valeur", LongText = "S2 - Travailleurs de la chaîne de valeur", State = StateEnum.active, LanguageId = 2, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow },
                new Standard { Id = 22, Code = "S3", ShortText = "S3 - Communautés affectées", LongText = "S3 - Communautés affectées", State = StateEnum.active, LanguageId = 2, TopicId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow });
                }
    }
}
