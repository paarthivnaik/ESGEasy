using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.Language;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.Infrastructure.Persistence.LanguageRepo
{
    public class LanguageRepo : GenericRepository<Language>,ILanguageRepo
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LanguageTranslation>> GetLanguagesByLanguageId(long languageId)
        {            
            var list = await _context.LanguageTranslations
                                     .AsNoTracking()
                                     .Where(uom => (uom.LanguageId == languageId) && (uom.State == Domain.Enum.StateEnum.active))
                                     .ToListAsync();
            return list;
        }
    }
}
