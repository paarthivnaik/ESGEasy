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

        //public async Task<List<DimensionType>> GetDimensionTypesByModelId(long modelId)
        //{
        //    var dimensionTypes = await _context.ModelDimensionTypes
        //        .AsNoTracking()
        //        .Where(a => a.DataModelId == modelId)
        //        .SelectMany(a => a.DimensionType) 
        //        .Select(dt => new DimensionType
        //        {
        //            Id = dt.Id, 
        //            ShortText = dt.ShortText 
        //        })
        //        .ToListAsync();
        //    return dimensionTypes;
        //}

        public async Task<List<ESG.Domain.Entities.DataModel>?> GetDataModelsByOrgId(long OrgId)
        {
            var list = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == OrgId)
                .Select(dp => new ESG.Domain.Entities.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .ToListAsync();
            return list;
        }
        public async Task<(long Id, string Name)> GetRowDimensionTypeIdAndNameFromConfigurationByModelId(long modelId)
        {
            var result = await _context.ModelConfiguration
                .AsNoTracking()
                .Include(a => a.Row) 
                .Where(a => a.DataModelId == modelId)
                .Select(a => new
                {
                    a.RowId,
                    RowName = a.Row.ShortText 
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return (result.RowId, result.RowName);
            }
            return (default(long), string.Empty);
        }
        public async Task<(long Id, string Name)> GetColumnDimensionTypeIdAndNameByDimensionTypeId(long typeId)
        {
            var result = await _context.DimensionTypes
                .AsNoTracking()
                .Where(a => a.Id == typeId)
                .Select(a => new
                {
                    a.Id,
                    a.ShortText,
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return (result.Id, result.ShortText);
            }
            return (default(long), string.Empty);
        }
        public async Task<long> GetModelconfigurationIdByModelId(long modelId)
        {
            var ids = await _context.ModelConfiguration
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
            return ids;
        }

        public async Task<IEnumerable<(long Id, string Name)>> GetDimensionValuesByTypeId(long? modelDimensionTypeId)
        {
            var result = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(md => md.ModelDimensionTypesId == modelDimensionTypeId)
                .Include(a => a.Dimensions) 
                .Select(md => new 
                {
                    Id = md.Dimensions.Id, 
                    Name = md.Dimensions.ShortText
                })
                .ToListAsync();
            if (result != null)
            {
                return result.Select(x => (x.Id, x.Name));
            }
            return Enumerable.Empty<(long, string)>();
        }
        public async Task<long?> GetColumnIdInModelCnfigurationByModelId(long modelId)
        {
            var columnId = await _context.ModelConfiguration
                .AsNoTracking()
                .Where(md => md.DataModelId == modelId)
                .Select(a => a.ColumnId)
                .FirstOrDefaultAsync();
            return columnId;
        }
        public async Task<long?> GetModelDimensionTypeIdByDimensiionTypeID(long dimensionTypeId)
        {
            var modeldimensionTypeId = await _context.ModelDimensionTypes
                .AsNoTracking()
                .Include(a => a.ModelDimensionValues)
                .Where(md => md.DimensionTypeId == dimensionTypeId)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
            return modeldimensionTypeId;
        }

        public async Task<IEnumerable<(long Id, string Name)>> GetFilterDimensionTypeByConfigurationId(long configurationId)
        {
            var result = await _context.DataModelFilters
                 .AsNoTracking()
                 .Where(md => md.ModelConfigurationId == configurationId)
                 .Include(a => a.DimensionType)
                 .Select(md => new
                 {
                     Id = md.DimensionType.Id,
                     Name = md.DimensionType.ShortText
                 })
                 .ToListAsync();
            if (result != null)
            {
                return result.Select(x => (x.Id, x.Name));
            }
            return Enumerable.Empty<(long, string)>();
        }
    }
}
