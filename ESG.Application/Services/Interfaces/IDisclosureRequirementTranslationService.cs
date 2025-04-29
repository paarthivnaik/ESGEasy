using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Services.Interfaces
{
    public interface IDisclosureRequirementTranslationService
    {
        Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslations(long? langId);
        Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslationsById(long? languageId,long id); 
    }
}
