using ESG.Application.Dto.UOMTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionTranslationService
    {
        Task Add(UOMTranslationsCreateRequestDto uOMTranslationsCreateRequestDto);
    }
}
