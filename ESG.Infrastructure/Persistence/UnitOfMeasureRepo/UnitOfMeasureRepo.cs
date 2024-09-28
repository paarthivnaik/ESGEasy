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
    }
}
