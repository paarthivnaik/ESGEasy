using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.Dimensions;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.Infrastructure.Persistence.DimensionRepo
{
    public class DimensionTypeRepo : GenericRepository<DimensionType>,IDimensionTypeRepo
    {
        private readonly ApplicationDbContext _context;
        public DimensionTypeRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DimensionType>> GetDimensionTypeTranslations(long? langId,long? organizationId)
        {
            var list = await _context.DimensionTypes
                .Where(dt =>(dt.OrganizationId == organizationId || dt.OrganizationId == 1)&& dt.State == Domain.Enum.StateEnum.active)
                .Select(u => new DimensionType
                {
                    Id = u.Id,
                    Code = u.Code,
                    LanguageId = (long)langId,
                    OrganizationId = u.OrganizationId,
                    State = u.State,
                    ShortText = u.DimensionTypeTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault(),
                    LongText = u.DimensionTypeTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return list;
        }
    }
}
