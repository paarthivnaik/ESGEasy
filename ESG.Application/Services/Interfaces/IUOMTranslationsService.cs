using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UOMTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUOMTranslationsService
    {
        Task Add(UOMTranslationsCreateRequestDto uOMTranslationsCreateRequestDto);
        Task Update(UOMTranslationsUpdateRequestDto unitOfMeasure);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetUOMTranslationsByLanguageId(long languageId);
    }
}
