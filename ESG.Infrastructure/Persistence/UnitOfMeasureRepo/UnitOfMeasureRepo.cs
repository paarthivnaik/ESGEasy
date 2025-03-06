using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.UnitOfMeasureRepo
{
    public class UnitOfMeasureRepo : GenericRepository<UnitOfMeasure>, IUnitOfMeasureRepo
    {
        private readonly ApplicationDbContext _context;
        public UnitOfMeasureRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UnitOfMeasureTranslation>> GetAllUOMTranslationsByUOMId(long id)
        {
            var list = await _context.UnitOfMeasureTranslations
                                     .AsNoTracking()
                                     .Where(uom => uom.UnitOfMeasureId == id)
                                     .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<UnitOfMeasure>> GetAllUOMTranslationsByUOMIdLangId(long id ,long langId, long organizationId)
        {
            var list = await _context.UnitOfMeasures
                .Where(uom=>(uom.UnitOfMeasureTypeId == id) && (uom.OrganizationId == organizationId))
                .Select(u => new UnitOfMeasure
            {
                Id = u.Id,
                Code = u.Code,
                UnitOfMeasureTypeId = id,
                LanguageId = langId,
                OrganizationId = u.OrganizationId,
                State = u.State,
                ShortText = u.UnitOfMeasureTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault() ?? u.ShortText,
                LongText = u.UnitOfMeasureTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault() ?? u.LongText
            })                
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<UnitOfMeasure>> GetAllUOMDetails(long OrganizationId)
        {
            var list = await _context.UnitOfMeasures
                                     .AsNoTracking()
                                     .Where(a => a.OrganizationId == 1 || a.OrganizationId == OrganizationId)
                                     .Include(a => a.UnitOfMeasureType)
                                     .ToListAsync();
            return list;
        }
    }
}
