using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Dto.DataModel;
using ESG.Domain.Entities.DataModels;
using ESG.Domain.Entities.DomainEntities;
using ESG.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

        public async Task<List<Domain.Entities.DataModels.DataModel>> GetDataModelsIncludingDefaultByOrgId(long OrgId)
        {
            var organizationDataModels = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == OrgId)
                .Select(dp => new ESG.Domain.Entities.DataModels.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .ToListAsync();
            var defaultDataModel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.IsDefaultModel == true)
                .Select(dp => new ESG.Domain.Entities.DataModels.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .FirstOrDefaultAsync();
            if (defaultDataModel != null && !organizationDataModels.Any(dm => dm.Id == defaultDataModel.Id))
            {
                organizationDataModels.Add(defaultDataModel);
            }
            return organizationDataModels;
        }

        public async Task<Domain.Entities.DataModels.DataModel?> GetDataModelIdByDatapointIdAndOrgId(long datapointId, long orgId)
        {
            var dataModel = await _context.DataModels
                .AsNoTracking()
                .Include(a => a.ModelDatapoints)
                .Where(a => a.OrganizationId == orgId && a.IsDefaultModel == false && a.ModelDatapoints.Any(md => md.DatapointValuesId == datapointId))
                .Select(dp => new ESG.Domain.Entities.DataModels.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .FirstOrDefaultAsync();
            if (dataModel == null)
                return new Domain.Entities.DataModels.DataModel
                {
                    Id = 1,
                    ModelName = "Default Model"
                };
            return dataModel;
        }

        public async Task<(long Id, string Name)> GetRowDimensionTypeIdAndNameFromConfigurationByModelId(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var result = await _context.ModelConfiguration
                .AsNoTracking()
                .Include(a => a.Row) 
                .Where(a => a.DataModelId == modelId && a.ViewType == viewTypeEnum)
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
        public async Task<long> GetModelconfigurationIdByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var ids = await _context.ModelConfiguration
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId && a.ViewType == viewTypeEnum)
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
        public async Task<long?> GetColumnIdInModelCnfigurationByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var columnId = await _context.ModelConfiguration
                .AsNoTracking()
                .Where(md => md.DataModelId == modelId && md.ViewType == viewTypeEnum)
                .Select(a => a.ColumnId)
                .FirstOrDefaultAsync();
            return columnId;
        }
        public async Task<long?> GetModelDimensionTypeIdByDimensiionTypeID(long modelId, long dimensionTypeId)
        {
            var modeldimensionTypeId = await _context.ModelDimensionTypes
                .AsNoTracking()
                .Include(a => a.ModelDimensionValues)
                .Where(md => md.DimensionTypeId == dimensionTypeId && md.DataModelId == modelId)
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
        public async Task<List<ModelConfiguration>> GetConfigurationViewTypesForDataModel(long datamodelId)
        {
            var modeldimensionTypeId = await _context.ModelConfiguration
                .AsNoTracking()
                .Where(md => md.DataModelId == datamodelId)
                .ToListAsync();
            return modeldimensionTypeId;
        }

        public async Task<bool?> GetDatapointViewType(long datapointId)
        {
            var viewType = await _context.DataPointValues
                .AsNoTracking()
                .Where(md => md.Id == datapointId)
                .Select(md => md.IsNarrative)
                .FirstOrDefaultAsync();

            return viewType;
        }

        public async Task<IEnumerable<DataModelFilters>> GetModelFiltersByConfigId(long configId)
        {
            var filters = await _context.DataModelFilters
                .AsNoTracking()
                .Where(md => md.ModelConfigurationId == configId)
                .ToListAsync();
            return filters;
        }
    }
}
