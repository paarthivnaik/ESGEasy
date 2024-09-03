using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Dto.DataModel;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataModel
{
    public class DataModelRepo : GenericRepository<DataPointValues>, IDataModelRepo
    {
        private readonly ApplicationDbContext _context;
        public DataModelRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<long>?> GetDimensionTypesByModelId(long modelId)
        {
            var list = await _context.ModelDimensionTypes
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId)
                .Select(a => a.DimensionTypeId)
                .ToListAsync();

            return list;
        }


        public async Task<List<long>?> GetDimensionValuesByModelId(long modelId)
        {
            var list = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId)
                .Select(a => a.DimensionsId)
                .ToListAsync();
            return list;
        }

    }
}
