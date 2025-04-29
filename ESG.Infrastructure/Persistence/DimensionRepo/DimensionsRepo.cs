using ESG.Application.Common.Interface.Dimension;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DimensionRepo
{
    public class DimensionsRepo : GenericRepository<UnitOfMeasure>, IDimensionRepo
    {
        private readonly ApplicationDbContext _context;
        public DimensionsRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DimensionTranslation>> GetAllTranslations(long id)
        {
            var list = await _context.DimensionTranslations
                                     .Where(uom => uom.DimensionsId == id)
                                     .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Dimension>> GetDimensionTranslationsByDimensionId(long dimensionTypeid,long languageId,long organizationId)
        {
            var list = await _context.Dimensions
                .Where(d=>(d.DimensionTypeId == dimensionTypeid) && (d.OrganizationId == 1||d.OrganizationId == organizationId)&& (d.State == Domain.Enum.StateEnum.active))
                .Select(d => new Dimension
                {
                    Id = d.Id,
                    DimensionTypeId = d.DimensionTypeId,
                    Code = d.Code,
                    LanguageId = languageId,
                    ShortText = d.DimensionTranslations
                    .Where(dt => dt.LanguageId == languageId)
                    .Select(dt => dt.ShortText)
                    .FirstOrDefault(),
                    LongText = d.DimensionTranslations
                    .Where(t => t.LanguageId == languageId)
                    .Select(t => t.LongText)
                    .FirstOrDefault()

                })
                .ToListAsync();
            return list;
        }
    }
}
