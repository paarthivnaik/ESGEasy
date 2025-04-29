using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Dto.Language;
using ESG.Domain.Models;

namespace ESG.Application.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageDto>> GetAll();
        Task<LanguageDto> GetById(long id);
        Task<IEnumerable<LanguageTranslation>> GetLanguageTranslationsByLanguageId(long languageId);
    }
}
