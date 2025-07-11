﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Language
{
    public interface ILanguageRepo
    {
        Task<IEnumerable<Domain.Models.LanguageTranslation>> GetLanguagesByLanguageId(long languageId);
    }
}
