using ESG.Application.Dto.DimensionTypeTranslation;
using ESG.Application.Dto.UOMTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionTypeTranslationService
    {
        Task Add(DimensionTypeTranslationCreateRequestDto translationsCreateRequestDto);
        Task<IEnumerable<DimensionType>> GetAllTranslations(long? languageId, long? organizationId);
    }
}
