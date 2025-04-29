using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.Currency;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ESG.Infrastructure.Persistence.CurrencyRepo
{
    public class CurrencyRepo :GenericRepository<Domain.Models.Currency>,ICurrencyRepo
    {
        private readonly ApplicationDbContext _context;
        public CurrencyRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Currency>> GetCurrenciesTranslations(long? languageId)
        {
            var list = await _context.Currencies
                .Select(c => new Currency
                {
                    Id = c.Id,
                    Name = c.Name,
                    CurrencyCode = c.CurrencyCode,
                    LanguageId = (long)languageId,
                    ShortText = c.CurrencyTranslations
                    .Where(ct => ct.LanguageId == languageId)
                    .Select(ct => ct.ShortText)
                    .FirstOrDefault(),
                    LongText = c.CurrencyTranslations
                    .Where(ct => ct.LanguageId == languageId)
                    .Select(ct => ct.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();            
            return list;
        }
    }
}
