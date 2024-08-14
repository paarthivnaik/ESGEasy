using ESG.Application.Common.Interface.Dimensions;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.Dimensions;
using ESG.Domain.Entities;
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

        public async Task<IEnumerable<ESG.Domain.Entities.DimensionTranslations>> GetAllTranslations(long id)
        {
            var list = await _context.DimensionTranslations
                                     .Where(uom => uom.DimensionsId == id)
                                     .ToListAsync();
            return list;
        }
    }
}
