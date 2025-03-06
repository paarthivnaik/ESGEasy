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
    public class UnitOfMeasureTypeRepo : GenericRepository<UnitOfMeasureType>, IUnitOfMeasureTypeRepo
    {
        public readonly ApplicationDbContext _applicationDb;
        public UnitOfMeasureTypeRepo(ApplicationDbContext context) : base(context)
        {
            _applicationDb = context;
        }
        public async Task<IEnumerable<UnitOfMeasureType>> GetAllUOMTranslationsByUOMIdLangId(long langId, long organizationId)
        {
            var list = await _applicationDb.UnitOfMeasureTypes
                .Where(uom => uom.OrganizationId == organizationId)
                .Select(u => new UnitOfMeasureType
                {
                    Id = u.Id,
                    Code = u.Code,                    
                    LanguageId = langId,
                    OrganizationId = u.OrganizationId,
                    State = u.State,
                    ShortText = u.UnitOfMeasureTypeTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault() ?? u.ShortText,
                    LongText = u.UnitOfMeasureTypeTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault() ?? u.LongText
                })
                .ToListAsync();
            return list;
        }
    }
}
