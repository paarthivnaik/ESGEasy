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

        public async Task<List<Domain.Models.DataModel>> GetDataModelsIncludingDefaultByOrgId(long OrgId, bool hasValues)
        {
            var defaultDataModel = new Domain.Models.DataModel();
            var organizationDataModels = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == OrgId && a.State == StateEnum.active)
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName,
                    IsDefaultModel = dp.IsDefaultModel,
                })
                .ToListAsync();
            if (hasValues == true)
            {
                defaultDataModel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.IsDefaultModel == true)
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName,
                    IsDefaultModel = dp.IsDefaultModel,
                })
                .FirstOrDefaultAsync();
            }
            if (!organizationDataModels.Any(dm => dm.Id == defaultDataModel?.Id) && defaultDataModel?.Id > 0)
            {
                organizationDataModels.Add(defaultDataModel);
            }
            return organizationDataModels;
        }

        public async Task<Domain.Models.DataModel?> GetDataModelByDatapointIdAndOrgId(long datapointId, long orgId)
        {
            var dataModel = await _context.DataModels
                .AsNoTracking()
                .Include(a => a.ModelDatapoints)
                .Where(a => a.OrganizationId == orgId && a.IsDefaultModel == false && a.ModelDatapoints.Any(md => md.DatapointValuesId == datapointId))
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName,
                    IsDefaultModel = dp.IsDefaultModel,
                })
                .FirstOrDefaultAsync();
            if (dataModel == null)
                return new Domain.Models.DataModel
                {
                    Id = 1,
                    ModelName = "Default Model",
                    IsDefaultModel = true,
                };
            return dataModel;
        }
        
        public async Task<ESG.Domain.Models.DataModel?> GetDataModelById(long modelId)
        {
            return await _context.DataModels
                .AsNoTracking()
                .Where(a => a.Id == modelId)
                .FirstOrDefaultAsync();
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
                    RowName = a.Row.Name ?? a.Row.ShortText 
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
                    Name = a.Name ?? a.ShortText
                })
                .FirstOrDefaultAsync();

            if (result != null)
            {
                return (result.Id, result.Name);
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
                    Name = md.Dimensions.Name ?? md.Dimensions.ShortText,
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
                    Name = md.Filter.Name ?? md.Filter.ShortText,
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
            //var dataModel = await _context.DataPointValue
            //   .AsNoTracking()
            //   .Include(a => a.UnitOfMeasure)
            //   .Include(c => c.Currency)
            //   .Where(a => a.organizationId == organizationId && a.Id == datapointId)
            //   .FirstOrDefaultAsync();
            //return dataModel;
            try
            {
                var dataModel = (from dpv in _context.DataPointValue.AsNoTracking()
                                 join uom in _context.UnitOfMeasures on dpv.UnitOfMeasureId equals uom.Id into uomGroup
                                 from uom in uomGroup.DefaultIfEmpty() // Left join for UnitOfMeasure
                                 join cur in _context.Currencies on dpv.CurrencyId equals cur.Id into curGroup
                                 from cur in curGroup.DefaultIfEmpty() // Left join for Currency
                                 join dpt in _context.DataPointType on dpv.DatapointTypeId equals dpt.Id into dptGroup
                                 from dpt in dptGroup.DefaultIfEmpty() // Left join for DatapointType
                                 where dpv.OrganizationId == organizationId && dpv.Id == datapointId
                                 select new DataPointValue
                                 {
                                     Id = dpv.Id,
                                     Code = dpv.Code,
                                     Name = dpv.Name,
                                     UnitOfMeasureId = uom != null ? uom.Id : (int?)null,
                                     CurrencyId = cur != null ? cur.Id : (int?)null,
                                     UnitOfMeasure = uom,
                                     Currency = cur
                                 }).FirstOrDefault();



                return dataModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Proble in getDataPointMetric: " + ex.ToString() + "\n" + ex.InnerException );
            }
        }


        public async Task<IEnumerable<DataModelValue>> GetDataModelValuesByDatapointIdCombinatinalIdAndModelId(long? combinationId, long datapointId, long modelId)
        {
            if (combinationId == 0)
                combinationId = null;
            var modelvalues = await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.CombinationId == combinationId && a.DataPointValuesId == datapointId && a.DataModelId == modelId)
                .ToListAsync();
            return modelvalues;
        }
        public async Task<IEnumerable<DefaultDataModelValue>> GetDefaultDataModelValuesByDatapointIdCombinatinalIdAndModelId(long? combinationId, long datapointId, long modelId)
        {
            if (combinationId == 0)
                combinationId = null;
            var modelvalues = await _context.DefaultDataModelValues
                .AsNoTracking()
                .Where(a => a.DataPointValuesId == datapointId )
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

        public async Task<IEnumerable<ModelFilterCombination>> GetModelFilterCombinationsByModelIdandDatapointId(long modelId, long datapointId, ModelViewTypeEnum viewType)
        {
            var modelCombinations = await _context.ModelFilterCombinations
                    .AsNoTracking()
                    .Include(a => a.SampleModelFilterCombinationValues)
                    .ThenInclude(cv => cv.DataModelFilters)
                    .Where(dp => dp.DataModelId == modelId && dp.ViewType == viewType)
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
        public async Task<List<DataModelValue>?> GetDataModelValuesByModelIdOrgId(long modelId, long organizationId)
        {
            return await _context.DataModelValues
                .Where(dmv =>
                    dmv.DataModelId == modelId &&
                    dmv.DataModel.OrganizationId == organizationId)
                .Include(a => a.DataPointValues)
                .Include(dim => dim.Row)
                .Include(df => df.Combination)
                .ThenInclude(mfc => mfc.SampleModelFilterCombinationValues)
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
                    TypeId = md.Dimensions.DimensionTypeId,
                })
                .ToListAsync();

            return result.Any() ? result.Select(x => (x.Id, x.Name, x.TypeId)) : Enumerable.Empty<(long, string, long)>();
        }

        public async Task<List<(long Id, long DimensionTypeId, string Name)>> GetModelDimensionTypesByModelDimTypeId(long modelId, long organizationId)
        {
            var query = _context.ModelDimensionTypes
                .AsNoTracking()
                .Where(md => md.DataModelId == modelId &&
                             (modelId == 1 || md.DataModel.OrganizationId == organizationId))
                .Include(md => md.DimensionType)
                .Select(md => new
                {
                    Id = md.Id,
                    DimensionTypeId = md.DimensionType.Id,
                    Name = md.DimensionType.Name ?? md.DimensionType.ShortText,
                });

            var result = await query.ToListAsync();
            return result.Select(x => (x.Id, x.DimensionTypeId, x.Name)).ToList();
        }



        public async Task<Amendment?> GetExistingAmendment(long datapointId, long? combinationId)
        {
            return await _context.Amendments
                .AsNoTracking()
                .Where(a => a.DatapointId == datapointId && a.FilterCombinationId == combinationId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DataModelValue>?> GetDataModelValuesById(List<long> ids, long modelId, long organizationId)
        {
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(dmv => ids.Contains(dmv.Id) && dmv.DataModelId == modelId && dmv.DataModel.OrganizationId == organizationId)
                .ToListAsync();
        }
        public async Task<List<DefaultDataModelValue>?> GetDefaultDataModelValuesById(List<long> ids)
        {
            return await _context.DefaultDataModelValues
                .AsNoTracking()
                .Where(dmv => ids.Contains(dmv.Id))
                .ToListAsync();
        }
        public async Task<List<DataModelValue>?> GetDataModelValuesById(List<long> ids)
        {
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(dmv => ids.Contains(dmv.Id))
                .ToListAsync();
        }

        public async Task<bool> VerifyIsDefaultModel(long modelId)
        {
            var res = await _context.DataModels
                .AsNoTracking()
                .Where(dm => dm.Id == modelId)
                .Select(dmv => dmv.IsDefaultModel)
                .FirstOrDefaultAsync();
            return res;
        }
        public async Task<IEnumerable<DefaultDataModelValue>?> GetDefaultDataModelValuesByDatapointIds(List<long> datapointIds, StateEnum state, long organizationId)
        {
            var modelvalues = await _context.DefaultDataModelValues
                .AsNoTracking()
                .Where(a => a.DataPointValuesId.HasValue && datapointIds.Contains(a.DataPointValuesId.Value) && a.State == state && a.OrganizationId == organizationId)
                .ToListAsync();
            return modelvalues;
        }

        public async Task<Domain.Models.DataModel> GetDefaultModel()
        {
            var datamodel = await _context.DataModels
                .AsNoTracking()
                .Include(b => b.ModelDimensionTypes)
                .Include(a => a.ModelConfigurations)
                .Include(a => a.ModelFilterCombinations)
                .Where(a => a.IsDefaultModel == true)
                .FirstOrDefaultAsync();
            return datamodel;
        }

        public async Task<List<(long Id, long typeId)>> GetModelDimensionValuesByTypeIdAndModelId(long modeldimtypeId, long modelId)
        {
            var list = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(a => a.ModelDimensionTypesId == modeldimtypeId && a.ModelDimensionTypes.DataModel.Id == modelId)
                .Select(a => new
                {
                    Id = a.DimensionsId,
                    typeId = a.ModelDimensionTypes.DimensionTypeId
                })
                .ToListAsync();

            return list.Select(a => (a.Id, a.typeId)).ToList();
        }
        public async Task<List<DefaultDataModelValue>?> GetDefaultDataModelValuesByModelIdAndDatapoints(long modelId, IEnumerable<long> datapoints, long organizationId)
        {
            return await _context.DefaultDataModelValues
                .Include(a => a.DataPointValues)
                .Include(dim => dim.Row)
                .Include(dim => dim.Column)
                .Include(df => df.Combination)
                    .ThenInclude(mfc => mfc.SampleModelFilterCombinationValues)
                .Where(dmv => dmv.DataModelId == modelId
                    && dmv.DataPointValuesId.HasValue
                    && datapoints.Contains(dmv.DataPointValuesId.Value)
                    && dmv.OrganizationId == organizationId)
                .ToListAsync();
        }
        //public async Task<ESG.Domain.Models.DataModel?> GetDataModelById(long dataModelId)
        //{
        //    return await _context.DataModels
        //        .AsNoTracking()
        //        .Where(a => a.Id == dataModelId)
        //        .FirstOrDefaultAsync();
        //}

        public async Task<List<long>?> GetDataModelValuesyOrgaidAndResponsibleUser(long organizationId, long userId)
        {
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.DataModel.OrganizationId == organizationId && a.ResponsibleUserId == userId)
                .Select(b => b.DataPointValuesId)
                .Distinct()
                .ToListAsync();
        }
        public async Task<List<long?>> GetDefaultDataModelValuesyOrgaidAndResponsibleUser(long organizationId, long userId)
        {
            return await _context.DefaultDataModelValues
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId && a.ResponsibleUserId == userId)
                .Select(b => b.DataPointValuesId)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Amendment?> GetAmendmentById(long? id)
        {
            return await _context.Amendments
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIsDefaultdataModelvalues(long orgId)
        {
            return await _context.DefaultDataModelValues
                .AsNoTracking()
                .AnyAsync(a => a.OrganizationId == orgId);
        }

    }
}
