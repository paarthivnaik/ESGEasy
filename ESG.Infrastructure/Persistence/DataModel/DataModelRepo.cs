using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Dto.DataModel;
using ESG.Domain.Models;
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
    public class DataModelRepo : GenericRepository<DataPointValue>, IDataModelRepo
    {
        private readonly ApplicationDbContext _context;
        public DataModelRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DataModel>> GetDataModelsIncludingDefaultByOrgId(long OrgId)
        {
            var organizationDataModels = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == OrgId)
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .ToListAsync();
            var defaultDataModel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.IsDefaultModel == true)
                .Select(dp => new ESG.Domain.Models.DataModel
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

        public async Task<Domain.Models.DataModel?> GetDataModelIdByDatapointIdAndOrgId(long datapointId, long orgId)
        {
            var dataModel = await _context.DataModels
                .AsNoTracking()
                .Include(a => a.ModelDatapoints)
                .Where(a => a.OrganizationId == orgId && a.IsDefaultModel == false && a.ModelDatapoints.Any(md => md.DatapointValuesId == datapointId))
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName
                })
                .FirstOrDefaultAsync();
            if (dataModel == null)
                return new Domain.Models.DataModel
                {
                    Id = 1,
                    ModelName = "Default Model"
                };
            return dataModel;
        }

        public async Task<(long Id, string Name)> GetRowDimensionTypeIdAndNameFromConfigurationByModelId(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var result = await _context.ModelConfigurations
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
            var id = await _context.ModelConfigurations
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId && a.ViewType == viewTypeEnum)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
            return id;
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
            var columnId = await _context.ModelConfigurations
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

        public async Task<List<(long Id, string? Name)>?> GetFilterDimensionTypeByConfigurationId(long configurationId)
        {
            if (_context.DataModelFilters == null)
            {
                return null; 
            }

            var result = await _context.DataModelFilters
                .AsNoTracking()
                .Where(md => md.ModelConfigurationId == configurationId)
                .Include(a => a.DimensionType)
                .Select(md => new
                {
                    Id = (long?)md.FilterId,  
                    Name = md.Filter.ShortText
                })
                .ToListAsync();

            if (result == null || !result.Any())
            {
                return null;
            }

            return result
                .Where(x => x.Id.HasValue && !string.IsNullOrEmpty(x.Name))
                .Select(x => (x.Id.Value, x.Name))
                .ToList();
        }



        public async Task<List<ModelConfiguration>> GetConfigurationViewTypesForDataModel(long datamodelId)
        {
            var modeldimensionTypeId = await _context.ModelConfigurations
                .AsNoTracking()
                .Where(md => md.DataModelId == datamodelId)
                .ToListAsync();
            return modeldimensionTypeId;
        }

        public async Task<bool?> GetDatapointViewType(long datapointId)
        {
            var viewType = await _context.DataPointValue
                .AsNoTracking()
                .Where(md => md.Id == datapointId)
                .Select(md => md.IsNarrative)
                .FirstOrDefaultAsync();

            return viewType;
        }

        public async Task<List<long>> GetDatapointsByViewType(List<long> datapointIds)
        {
            var narrativeDatapoints = await _context.DataPointValue
                .AsNoTracking()
                .Where(md => datapointIds.Contains(md.Id) && md.IsNarrative == true) 
                .Select(md => md.Id) 
                .ToListAsync();
            return narrativeDatapoints;
        }
        public async Task<DataPointValue> GetDatapointMetric(long datapointId, long organizationId)
        {
            var dataModel = await _context.DataPointValue
               .AsNoTracking()
               .Include(a => a.UnitOfMeasure)
               .Include(c => c.Currency)
               .Include(d => d.DatapointType)
               .Where(a => a.OrganizationId == organizationId && a.Id == datapointId)
               .FirstOrDefaultAsync();
            return dataModel;
        }


        public async Task<IEnumerable<DataModelValue>> GetDataModelValuesByCombinationId(long combinationId)
        {
            var modelvalues = await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.CombinationId == combinationId)
                .ToListAsync();
            return modelvalues;
        }

        public async Task<List<ModelDimensionType>?> GetDimensionTypesByModelIdAndOrgId(long modelId, long orgId)
        {
            var modelvalues = await _context.ModelDimensionTypes
                .AsNoTracking()
                .Include(d => d.DimensionType)
                .Include(a => a.ModelDimensionValues)
                .ThenInclude(c => c.Dimensions)
                .Where(a => a.DataModelId == modelId && a.DataModel.OrganizationId == orgId)
                .ToListAsync();
            return modelvalues;
        }

        public async Task<IEnumerable<DataModelFilter>> GetModelFiltersByConfigId(long configId)
        {
            var filters = await _context.DataModelFilters
                .AsNoTracking()
                .Where(md => md.ModelConfigurationId == configId)
                .ToListAsync();
            return filters;
        }

        public async Task<IEnumerable<ModelFilterCombination>> GetModelFilterCombinationsByModelIdandDatapointId(long modelId, long datapointId)
        {
            var modelCombinations = await _context.ModelFilterCombinations
                    .AsNoTracking()
                    .Include(a => a.SampleModelFilterCombinationValues)
                    .ThenInclude(cv => cv.DataModelFilters)
                    .Where(dp => dp.DataModelId == modelId)
                    .ToListAsync();
            return modelCombinations;
        }
        public async Task<List<long>?> GetModelFilterCombinations(long modelId)
        {
            return await _context.ModelFilterCombinations
                .Where(mfc => mfc.DataModelId == modelId)
                .Include(mfc => mfc.ModelFilterCombinationalValues)
                .Select(a => a.Id)
                .ToListAsync();
        }

        public async Task<List<DataModelValue>?> GetDataModelValues(long modelId, long datapointId, List<long> rowId, List<long?> columnId, long? filterCombinationId)
        {
            return await _context.DataModelValues
                .Where(dmv =>
                    dmv.DataModelId == modelId &&
                    dmv.DataPointValuesId == datapointId &&
                    rowId.Contains(dmv.RowId) &&
                    (columnId.Contains(dmv.ColumnId) || (dmv.ColumnId == null && columnId.Contains(null))) &&
                    dmv.CombinationId == filterCombinationId)
                .ToListAsync();
        }
        public async Task<List<DataModelValuesDto>?> GetDataModelValuesByModelIdOrgId(long modelId, long organizationId)
        {
            return await _context.DataModelValues
                .Where(dmv =>
                    dmv.DataModelId == modelId &&
                    dmv.DataModel.OrganizationId == organizationId)
                .Include(a => a.DataPointValues)
                .Include(dim => dim.Row)         
                .Select(dmv => new DataModelValuesDto 
                {
                    DatapointId = dmv.DataPointValuesId,                
                    RowId = dmv.RowId,
                    ColumnId = dmv.ColumnId,
                    combinationId = dmv.CombinationId,
                    IsBlocked = dmv.IsBlocked,
                    Accountable = dmv.AccountableUserId
                })
                .ToListAsync();
        }
        public async Task<List<DataModelFilter>?> GetDataModelFiltersByConfigId(long configId)
        {
            return await _context.DataModelFilters
                .Where(dmf => dmf.ModelConfigurationId == configId)
                .ToListAsync();
        }
        public async Task<List<SampleModelFilterCombinationValue>?> GetDataModelCombinationalValuesByModelFilterCombinationIds(List<long> combinationalIds)
        {
            return await _context.SampleModelFilterCombinationValues
                .Where(dmf => combinationalIds.Contains(dmf.ModelFilterCombinationsId))
                .ToListAsync();
        }
        public async Task<IEnumerable<(long Id, string Name, long TypeId)>> GetModelDimensionValuesByModelDimTypeId(List<long?> modelDimensionTypeIds)
        {
            var result = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(md => modelDimensionTypeIds.Contains(md.ModelDimensionTypesId))
                .Include(a => a.Dimensions)
                .Select(md => new
                {
                    Id = md.Dimensions.Id,
                    Name = md.Dimensions.ShortText,
                    TypeId = md.ModelDimensionTypesId,
                })
                .ToListAsync();

            return result.Any() ? result.Select(x => (x.Id, x.Name, x.TypeId)) : Enumerable.Empty<(long, string, long)>();
        }

        public async Task<IEnumerable<(long Id, string Name)>> GetModelDimensionTypesByModelDimTypeId(long modelId, long organizationId)
        {
            var result = await _context.ModelDimensionTypes
                .AsNoTracking()
                .Where(md => md.DataModelId == modelId && md.DataModel.OrganizationId == organizationId)
                .Include(a => a.DimensionType)
                .Select(md => new
                {
                    Id = md.DimensionType.Id,
                    Name = md.DimensionType.ShortText
                })
                .ToListAsync();

            return result.Any() ? result.Select(x => (x.Id, x.Name)) : Enumerable.Empty<(long, string)>();
        }


        public async Task<Amendment?> GetExistingAmendment(long datapointId, long? combinationId)
        {
            return await _context.Amendments
                .AsNoTracking()
                .Where(a => a.DatapointId == datapointId && a.FilterCombinationId == combinationId)
                .FirstOrDefaultAsync();
        }
    }
}
