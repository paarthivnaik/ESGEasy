using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.DisclosureRequirement
{
    public interface IDisclosureRequirementRepo
    {
        Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetDisclosureRequirementsTranslations(long? langId);
        Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetDisclosureRequirementsTranslationsById(long? langId,long? Id);
        Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetAllDisclosureRequirements(Expression<Func<Domain.Models.DisclosureRequirement, bool>> predicate);
    }
}
