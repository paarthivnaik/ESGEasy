using ESG.Application.Common.Interface.Dimensions;
using ESG.Application.Common.Interface.Value;
using ESG.Application.Dto.Get;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.ValueRepo
{
    public class ValuesRepo : GenericRepository<UnitOfMeasure>, IValuesRepo
    {
        private readonly ApplicationDbContext _context;
        public ValuesRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UnitOfMeasureTranslations>> GetUOMTranslations(long? valueId)
        {
            var uomTranslations = await _context.UnitOfMeasureTranslations
                .AsNoTracking()
                .Where(t => t.UnitOfMeasureId == valueId.Value)
                .ToListAsync();
            return uomTranslations;
        }

        public async Task<IEnumerable<UnitOfMeasureTypeTranslations>> GetUOMTypeTranslations(long typeId)
        {
            var uomTranslation = await _context.UnitOfMeasureTypeTranslations
                            .AsNoTracking()
                            .Where(t => t.UnitOfMeasureTypeId == typeId)
                            .ToListAsync();
            return uomTranslation;
        }
        public async Task<IEnumerable<DimensionTranslations>> GetDimensionsTranslations(long typeId, long? valueId)
        {
            var uomTranslation = await _context.DimensionTranslations
                            .AsNoTracking()
                            .Where(t => t.DimensionsId == valueId.Value)
                            .ToListAsync();
            return uomTranslation;
        }
        public async Task<IEnumerable<DimensionTypeTranslations>> GetDimensionTypeTranslations(long typeId)
        {
            var uomTranslation = await _context.DimensionTypeTranslations
                            .AsNoTracking()
                            .Where(t => t.DimensionTypeId == typeId)
                            .ToListAsync();
            return uomTranslation;
        }
        public async Task<IEnumerable<DatapointValueTranslations>> GetDatapointTranslations(long typeId, long? valueId)
        {
            var uomTranslation = await _context.DatapointValueTranslations
                            .AsNoTracking()
                            .Where(t => t.DatapointValueId == valueId.Value)
                            .ToListAsync();
            return uomTranslation;
        }
        public async Task<IEnumerable<DatapointTypeTranslations>> GetDatapointTypeTranslations(long typeId)
        {
            var uomTranslation = await _context.DatapointTypeTranslations
                            .AsNoTracking()
                            .Where(t => t.DatapointTypeId == typeId)
                            .ToListAsync();
            return uomTranslation;
        }
    }
}
