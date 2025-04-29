using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Common.Interface.Currency
{
    public interface ICurrencyRepo
    {
        Task<IEnumerable<Domain.Models.Currency>> GetCurrenciesTranslations(long? languageId);
    }
}
