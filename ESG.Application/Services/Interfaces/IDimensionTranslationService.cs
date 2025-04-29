using ESG.Application.Dto.DimensionTranslation;
using ESG.Application.Dto.UOMTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionTranslationService
    {
        Task Add(DimensionTranslationCreateRequestDto uOMTranslationsCreateRequestDto);
        Task<IEnumerable<Dimension>> GetDimensionTranslationsByDimensionTypeId(long dimensionTypeId, long languageId, long organizationId);
    }
}
