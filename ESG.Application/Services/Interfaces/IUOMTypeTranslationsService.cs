using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UOMTypeTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUOMTypeTranslationsService
    {
        Task Add(UOMTypeTranslationsCreateRequestDto uomTypeTranslationsCreateRequestDto);
        Task Update(UOMTypeTranslationsUpdateRequestDto uomTypeTranslationsUpdateRequestDto);
        Task<IEnumerable<UOMTypeTranslationsCreateRequestDto>> GetUOMTranslationsByLanguageId(long languageId);
    }
}
