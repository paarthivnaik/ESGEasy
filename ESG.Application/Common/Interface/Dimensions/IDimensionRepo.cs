using ESG.Application.Dto.Dimension;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Dimension
{
    public interface IDimensionRepo
    {
        Task<IEnumerable<DimensionTranslation>> GetAllTranslations(long id);
        Task<IEnumerable<Domain.Models.Dimension>> GetDimensionTranslationsByDimensionId(long dimensionTypeId, long languageId, long organizationId);
    }
}
