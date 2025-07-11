﻿using ESG.Application.Common.Interface.DataModel;
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
using System.Diagnostics;
using ESG.Application.Dto.Hierarchy;

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
                    Purpose = dp.Purpose,
                })
                .ToListAsync();
            if (hasValues == true)
            {
                defaultDataModel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.IsDefaultModel == true 
                    && a.OrganizationId == OrgId
                    && a.State == StateEnum.active)
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName,
                    IsDefaultModel = dp.IsDefaultModel,
                    Purpose = dp.Purpose,
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
                .Where(a => a.OrganizationId == orgId 
                    && a.IsDefaultModel == false 
                    && a.ModelDatapoints.Any(md => md.DatapointValuesId == datapointId)
                    && a.State == StateEnum.active)
                .Select(dp => new ESG.Domain.Models.DataModel
                {
                    Id = dp.Id,
                    ModelName = dp.ModelName,
                    IsDefaultModel = dp.IsDefaultModel,
                })
                .FirstOrDefaultAsync();
            if (dataModel == null)
                dataModel = await _context.DataModels
                    .AsNoTracking()
                    .Where(a => a.OrganizationId == orgId 
                        && a.IsDefaultModel == true
                        && a.State == StateEnum.active)
                    .Select(dp => new ESG.Domain.Models.DataModel
                    {
                        Id = dp.Id,
                        ModelName = dp.ModelName,
                        IsDefaultModel = dp.IsDefaultModel,
                    })
                    .FirstOrDefaultAsync();
            return dataModel;
        }
        
        public async Task<ESG.Domain.Models.DataModel?> GetDataModelById(long modelId)
        {
            return await _context.DataModels
                .AsNoTracking()
                .Where(a => a.Id == modelId
                )
                .FirstOrDefaultAsync();
        }
        public async Task<(long Id, string Name)> GetRowDimensionTypeIdAndNameFromConfigurationByModelId(long modelId, ModelViewTypeEnum viewTypeEnum,long languageId)
        {
            var result = await _context.ModelConfigurations
                .AsNoTracking()
                .Include(a => a.Row) 
                .Where(a => a.DataModelId == modelId && a.ViewType == viewTypeEnum)
                .Select(a => new
                {
                    a.RowId,
                    RowName = a.Row.DimensionTypeTranslations
                    .Where(t => t.LanguageId == languageId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault()
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return (result.RowId, result.RowName);
            }
            return (default(long), string.Empty);
        }
        public async Task<(long Id, string Name)> GetColumnDimensionTypeIdAndNameByDimensionTypeId(long typeId,long languageId)
        {
            var result = await _context.DimensionTypes
                .AsNoTracking()
                .Where(a => a.Id == typeId)
                .Select(a => new
                {
                    a.Id,                    
                    Name = a.DimensionTypeTranslations
                    .Where(dt=>dt.LanguageId == languageId)
                    .Select(dt=>dt.ShortText)
                    .FirstOrDefault()
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

        public async Task<IEnumerable<(long Id, string Name)>> GetDimensionValuesByTypeId(long? modelDimensionTypeId,long languageId)
        {
            var result = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(md => md.ModelDimensionTypesId == modelDimensionTypeId)
                .Include(a => a.Dimensions) 
                .Select(md => new 
                {
                    Id = md.Dimensions.Id,                     
                    Name = md.Dimensions.DimensionTranslations
                    .Where(d=>d.LanguageId == languageId)
                    .Select(d=>d.ShortText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            if (result != null)
            {
                return result.Select(x => (x.Id, x.Name));
            }
            return Enumerable.Empty<(long, string)>();
        }
        public async Task<IEnumerable<ModelDimensionValue>> GetDimensionValuesToRemoveByTypeId(long? modelDimensionTypeId)
        {
            return await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(md => md.ModelDimensionTypesId == modelDimensionTypeId)
                .ToListAsync();
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

        public async Task<List<(long Id, string? Name)>?> GetFilterDimensionTypeByConfigurationId(long configurationId,long languageId)
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
                    Name = md.Filter.DimensionTypeTranslations
                    .Where(ft=>ft.LanguageId == languageId)
                    .Select(ft=>ft.ShortText)
                    .FirstOrDefault()
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
            if (viewType == null)
                return false;

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
                                     ShortText = dpv.ShortText,
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
        public async Task<IEnumerable<DataModelValue>> GetDefaultDataModelValuesByDatapointIdCombinatinalIdAndModelId(long? combinationId, long datapointId, long modelId)
        {
            if (combinationId == 0)
                combinationId = null;
            var modelvalues = await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.DataPointValuesId == datapointId )
                .ToListAsync();
            return modelvalues;
        }


        public async Task<List<ModelDimensionType>> GetDimensionTypesByModelIdAndOrgId(long modelId, long orgId)
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
        public async Task<List<ModelFilterCombination>?> GetModelFilterCombinations(long modelId)
        {
            return await _context.ModelFilterCombinations
                .Where(mfc => mfc.DataModelId == modelId)
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
        public async Task<List<long?>> GetDataModelValuesByDatapointIDsModelIdOrgId(List<long>? datapoints, long modelId, long organizationId)
        {
            return await _context.DataModelValues
                .Where(dmv =>
                    dmv.DataModelId == modelId &&
                    dmv.DataModel.OrganizationId == organizationId &&
                    datapoints.Contains(dmv.DataPointValuesId.Value) && 
                    dmv.Value != null)
                .Select(a => a.DataPointValuesId)
                .Distinct()
                .ToListAsync();
        }
        public async Task<List<DataModelValue>?> GetDataModelValuesByDatapointIDsOrgId(List<long>? datapoints, long organizationId)
        {
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(dmv =>
                    dmv.DataModel.OrganizationId == organizationId &&
                    datapoints.Contains(dmv.DataPointValuesId.Value))
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
        public async Task<IEnumerable<(long Id, string Name, long TypeId)>> GetModelDimensionValuesByModelDimTypeId(List<long?> modelDimensionTypeIds,long languageId)
        {
            var result = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(md => modelDimensionTypeIds.Contains(md.ModelDimensionTypesId))
                .Include(a => a.Dimensions)
                .Select(md => new
                {
                    Id = md.Dimensions.Id,                    
                    Name = md.Dimensions.DimensionTranslations
                    .Where(d => d.LanguageId == languageId)
                    .Select(d => d.ShortText)
                    .FirstOrDefault(),
                    TypeId = md.Dimensions.DimensionTypeId,
                })
                .ToListAsync();

            return result.Any() ? result.Select(x => (x.Id, x.Name, x.TypeId)) : Enumerable.Empty<(long, string, long)>();
        }

        public async Task<List<(long Id, long DimensionTypeId, string Name)>> GetModelDimensionTypesByModelDimTypeId(long modelId, long organizationId,long languageId)
        {
            var query = _context.ModelDimensionTypes
                .AsNoTracking()
                .Where(md => md.DataModelId == modelId && md.DataModel.OrganizationId == organizationId)
                .Include(md => md.DimensionType)
                .Select(md => new
                {
                    Id = md.Id,
                    DimensionTypeId = md.DimensionType.Id,                    
                    Name = md.DimensionType.DimensionTypeTranslations
                    .Where(dt=>dt.LanguageId == languageId)
                    .Select(dt=>dt.ShortText)
                    .FirstOrDefault()
                });

            var result = await query.ToListAsync();
            return result.Select(x => (x.Id, x.DimensionTypeId, x.Name)).ToList();
        }



        public async Task<Amendment?> GetExistingAmendment(long datapointId, long? combinationId, long organizationId)
        {
            return await _context.Amendments
                .AsNoTracking()
                .Where(a => a.DatapointId == datapointId && a.FilterCombinationId == combinationId && a.OrganizationId == organizationId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DataModelValue>?> GetDataModelValuesById(List<long> ids, long modelId, long organizationId)
        {
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(dmv => ids.Contains(dmv.Id) && dmv.DataModelId == modelId && dmv.DataModel.OrganizationId == organizationId)
                .ToListAsync();
        }
        public async Task<List<DataModelValue>?> GetDefaultDataModelValuesById(List<long> ids)
        {
            return await _context.DataModelValues
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
                .Select(dmv => dmv.IsDefaultModel && dmv.State == StateEnum.active)
                .FirstOrDefaultAsync();
            return res;
        }

        public async Task<Domain.Models.DataModel> GetDefaultModel(long organizationId)
        {
            var datamodel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId 
                    && a.IsDefaultModel == true
                    && a.State == StateEnum.active)
                .Include(b => b.ModelDimensionTypes)
                .Include(a => a.ModelConfigurations)
                .Include(a => a.ModelFilterCombinations)
                .FirstOrDefaultAsync();
            return datamodel;
        }

        public async Task<List<long>> GetModelDimensionValuesByTypeIdAndModelId(long? modeldimtypeId, long modelId)
        {
            var list = await _context.ModelDimensionValues
                .AsNoTracking()
                .Where(a => a.ModelDimensionTypesId == modeldimtypeId && a.ModelDimensionTypes.DataModel.Id == modelId)
                .Select(a => a.DimensionsId)
                .ToListAsync();

            return list;
        }
        public async Task<List<DataModelValue>?> GetDefaultDataModelValuesByModelIdAndDatapoints(long modelId, IEnumerable<long> datapoints, long organizationId,long languageId)
        {
            var res =  await _context.DataModelValues
                .Where(dmv => dmv.DataModelId == modelId
                    && dmv.DataPointValuesId.HasValue
                    && datapoints.Contains(dmv.DataPointValuesId.Value))
                //.Include(a => a.DataPointValues)
                .Include(a => a.DataPointValues)
                    .ThenInclude(dpv => dpv.DatapointValueTranslations
                    .Where(dv => dv.LanguageId == languageId))
                .Include(dim => dim.Row)
                    .ThenInclude(drv=>drv.DimensionTranslations
                    .Where(dr=>dr.LanguageId == languageId))
                .Include(dim => dim.Column)
                    .ThenInclude(dcv=>dcv.DimensionTranslations.
                    Where(dc=>dc.LanguageId == languageId))
                .Include(df => df.Combination)
                    .ThenInclude(mfc => mfc.SampleModelFilterCombinationValues)
                .ToListAsync();
            return res;
        }
        //public async Task<ESG.Domain.Models.DataModel?> GetDataModelById(long dataModelId)
        //{
        //    return await _context.DataModels
        //        .AsNoTracking()
        //        .Where(a => a.Id == dataModelId)
        //        .FirstOrDefaultAsync();
        //}

        public async Task<List<long?>> GetDataModelValuesyOrgaidAndResponsibleUser(long organizationId, long userId)
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
            return await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.ResponsibleUserId == userId)
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

        public async Task<List<UploadedFile>?> GetUploadedFileForDataModelValue(long id, bool isDefaultModel)
        {
            return await _context.UploadedFiles
                .AsNoTracking()
                .Where(a => a.DataModelValueId == id && a.IsDefaultModel == isDefaultModel)
                .ToListAsync();
        }
        public async Task<List<UploadedFile?>> GetUploadedFileData(long DataModelValueId, bool IsDefaultmodel)
        {
            var file = await _context.UploadedFiles
                .AsNoTracking()
                .Where(a => a.DataModelValueId == DataModelValueId && a.IsDefaultModel == IsDefaultmodel)
                .ToListAsync();
            return file;
        }

        public async Task<List<ModelDatapoint>> GetDatapointsLinkedToDataModel(long? modelId, long organizationId)
        {
            return await _context.ModelDatapoints
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId && a.DataModel.OrganizationId == organizationId)
                .ToListAsync();
        }
        public async Task<List<DatapointsDto>> GetDatapointsLinkedToDataModelWithName(long modelId, long organizationId,long languageId)
        {
            var result = await _context.ModelDatapoints
                .AsNoTracking()
                .Where(a => a.DataModelId == modelId && (a.DataModel.OrganizationId == organizationId || a.DataModel.OrganizationId == 1))
                .Include(a => a.DatapointValues)
                .Select(a => new DatapointsDto
                {
                    Id = a.DatapointValues.Id,
                    IsNarrative = a.DatapointValues.IsNarrative,
                    //ShortText = a.DatapointValues.ShortText,
                    ShortText = a.DatapointValues.DatapointValueTranslations
                    .Where(t => t.LanguageId == languageId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault(),
                })
                .ToListAsync();
            return result;
        }


        public async Task<List<(long Id,string? Value, long? DatapointId)>> GetDefaultDataModelValuesByOrganizationId(long organizationId)
        {
            var list = await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.DataModel.OrganizationId == organizationId && a.DataModel.State == StateEnum.active)
                .Select(a => new
                {
                    Id = a.Id,
                    Value = a.Value,
                    DatapointId = a.DataPointValuesId,
                })
                .ToListAsync();
            return list.Select(a => (a.Id, a.Value, a.DatapointId)).ToList();
        }

        public async Task<List<DataModelValue>> DataModelValuesByModelId(long dataModelId)
        {
           var list = await _context.DataModelValues
                .AsNoTracking()
                .Where(a => a.DataModelId == dataModelId)
                .ToListAsync();
            return list;
        }

        public async Task<Domain.Models.DataModel> GetDatamodelLinkedToDatapointByIdAndOrganizationId(long datapointId, long organizationId)
        {
            var datamodel = await _context.DataModels
                .AsNoTracking()
                .Where(a =>
                    a.OrganizationId == organizationId &&
                    a.ModelDatapoints.Any(b => b.DatapointValuesId == datapointId) &&
                    !a.IsDefaultModel
                    && a.State == StateEnum.active)
                .FirstOrDefaultAsync();

            return datamodel;
        }

        public async Task<List<long?>> IsDataPointHavinganyValue(CheckDataModelValueOfDatapointRegDto requestdto)
        {            
            var datapoints = await _context.DataModelValues
                .AsNoTracking()
                .Where(a =>
                    a.DataModel.OrganizationId == requestdto.OrganizationId &&
                    requestdto.DatapointIds.Contains(a.DataPointValuesId.Value) &&
                    a.Value != null)
                .Select(a => a.DataPointValuesId)
                .ToListAsync();
            return datapoints;
        }
        public async Task<bool> CheckModelIsEditable(long modelId, long organizationId)
        {
            var hasValue = await _context.DataModelValues
                .AsNoTracking()
                .AnyAsync(a =>
                    a.DataModel.OrganizationId == organizationId &&
                    a.DataModelId == modelId &&
                    (a.Value != null || a.UploadedFiles.Any()));
            return hasValue;
        }
        public async Task<bool> CheckDatapointIsDeletable(long datapointId, long organizationId)
        {
            var hasValue = await _context.DataModelValues
                .AsNoTracking()
                .AnyAsync(a =>
                    a.DataModel.OrganizationId == organizationId &&
                    a.DataPointValuesId == datapointId &&
                    a.Value != null);
            return hasValue;
        }

        public async Task<List<DataModelValue?>> GetDefaultDataModelValuesByDatapointIDsOrgId(List<long>? datapoints, long organizationId)
        {
            var hasValue = await _context.DataModelValues
                .AsNoTracking()
                .Where(a =>
                    a.DataModel.OrganizationId == organizationId &&
                    a.DataModel.IsDefaultModel == true &&
                    datapoints.Contains(a.DataPointValuesId.Value))
                .ToListAsync();
            return hasValue;
        }
        public async Task<List<DataModelValue?>> GetDataModelValuesByDatapointIDOrgId(long datapoint, long organizationId)
        {
            var hasValue = await _context.DataModelValues
                .AsNoTracking()
                .Where(a =>
                    a.DataModel.OrganizationId == organizationId &&
                    a.DataPointValuesId == datapoint )
                .ToListAsync();
            return hasValue;
        }
        public async Task<List<DataModelValue>> GenerateDataModelValues(List<long>? datapoints, long organizationId, long userId)
        {
            var defaultDatamodelValues = new List<DataModelValue>();

            var defaultDatamodel = await _context.DataModels
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId && a.IsDefaultModel == true)
                .Include(b => b.ModelDimensionTypes)
                .Include(a => a.ModelConfigurations)
                .Include(a => a.ModelFilterCombinations)
                .FirstOrDefaultAsync();
            if (defaultDatamodel != null && defaultDatamodel.Id > 0)
            {
                var factconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact).FirstOrDefault();
                var narrativeconfigId = defaultDatamodel.ModelConfigurations.Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative).FirstOrDefault();
                var factrowDimensions = new List<long>();
                var factcoldimensions = new List<long>();
                var factfiltercombinations = new List<long?>();
                var narrativerowDimensions = new List<long>();
                var narrativefiltercombinations = new List<long?>();
                if (factconfigId != null)
                {
                    var modeldimensiontypeIdforFactRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.RowId).FirstOrDefault();
                    var modeldimensiontypeIdforFactColumn = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == factconfigId.ColumnId).FirstOrDefault();
                    factrowDimensions = await _context.ModelDimensionValues
                    .AsNoTracking()
                    .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforFactRow.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                    .Select(a => a.DimensionsId)
                    .ToListAsync();                    
                    if (modeldimensiontypeIdforFactColumn != null)
                        factcoldimensions = await _context.ModelDimensionValues
                        .AsNoTracking()
                        .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforFactColumn.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                        .Select(a => a.DimensionsId)
                        .ToListAsync();                    
                    factfiltercombinations = defaultDatamodel.ModelFilterCombinations
                    .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Fact)
                    .Select(a => (long?)a.Id)
                    .ToList();
                }
                if (narrativeconfigId != null)
                {
                    var modeldimensiontypeIdforNarrativeRow = defaultDatamodel.ModelDimensionTypes.Where(a => a.DimensionTypeId == narrativeconfigId.RowId).FirstOrDefault();
                    narrativerowDimensions = await _context.ModelDimensionValues
                        .AsNoTracking()
                        .Where(a => a.ModelDimensionTypesId == modeldimensiontypeIdforNarrativeRow.Id && a.ModelDimensionTypes.DataModel.Id == defaultDatamodel.Id)
                        .Select(a => a.DimensionsId)
                        .ToListAsync();                    
                    narrativefiltercombinations = defaultDatamodel.ModelFilterCombinations
                        .Where(a => a.ViewType == Domain.Enum.ModelViewTypeEnum.Narrative)
                        .Select(a => (long?)a.Id).ToList();
                }
                foreach (var dp in datapoints)
                {
                    var viewtype = await _context.DataPointValue
                        .AsNoTracking()
                        .Where(md => md.Id == dp)
                        .Select(md => md.IsNarrative)
                        .FirstOrDefaultAsync();
                    if (viewtype == null)
                        viewtype = false;
                    if (viewtype != null && viewtype == true && narrativefiltercombinations.Count() != 0)
                    {
                        defaultDatamodelValues =
                        ( from rowDimension in narrativerowDimensions
                         from narrative in narrativefiltercombinations
                         select new DataModelValue
                         {
                             DataModelId = defaultDatamodel.Id,
                             DataPointValuesId = dp,
                             CreatedBy = userId,
                             LastModifiedBy = userId,
                             CreatedDate = DateTime.UtcNow,
                             LastModifiedDate = DateTime.UtcNow,
                             RowId = rowDimension,
                             ColumnId = null,
                             CombinationId = narrative,
                             State = Domain.Enum.StateEnum.active
                         }).ToList();
                    }
                    if (viewtype != null && viewtype == true && narrativefiltercombinations.Count() == 0)
                    {
                        defaultDatamodelValues =
                        (from rowDimension in narrativerowDimensions
                         select new DataModelValue
                         {
                             DataModelId = defaultDatamodel.Id,
                             DataPointValuesId = dp,
                             CreatedBy = userId,
                             LastModifiedBy = userId,
                             CreatedDate = DateTime.UtcNow,
                             LastModifiedDate = DateTime.UtcNow,
                             RowId = rowDimension,
                             ColumnId = null,
                             CombinationId = null,
                             State = Domain.Enum.StateEnum.active
                         }).ToList();
                    }
                    if (viewtype != null && viewtype == false && factfiltercombinations.Count() > 0 && factrowDimensions.Count() > 0)
                    {
                        defaultDatamodelValues =
                            ( from rowDimension in factrowDimensions
                             from colDimension in factcoldimensions
                             from factfilter in factfiltercombinations
                             select new DataModelValue
                             {
                                 DataModelId = defaultDatamodel.Id,
                                 DataPointValuesId = dp,
                                 CreatedBy = userId,
                                 LastModifiedBy = userId,
                                 CreatedDate = DateTime.UtcNow,
                                 LastModifiedDate = DateTime.UtcNow,
                                 RowId = rowDimension,
                                 ColumnId = colDimension,
                                 CombinationId = factfilter,
                                 State = Domain.Enum.StateEnum.active
                             }).ToList();
                    }
                    if (viewtype != null && viewtype == false && factfiltercombinations.Count() <= 0 && factcoldimensions.Count() > 0)
                    {
                        defaultDatamodelValues =
                            (from rowDimension in factrowDimensions
                             from colDimension in factcoldimensions
                             select new DataModelValue
                             {
                                 DataModelId = defaultDatamodel.Id,
                                 DataPointValuesId = dp,
                                 CreatedBy = userId,
                                 LastModifiedBy = userId,
                                 CreatedDate = DateTime.UtcNow,
                                 LastModifiedDate = DateTime.UtcNow,
                                 RowId = rowDimension,
                                 ColumnId = colDimension,
                                 CombinationId = null,
                                 State = Domain.Enum.StateEnum.active
                             }).ToList();
                    }
                    if (viewtype != null && viewtype == false && factfiltercombinations.Count() <= 0 && factcoldimensions.Count() == 0)
                    {
                        defaultDatamodelValues =
                            (from rowdim in factrowDimensions
                             select new DataModelValue
                             {
                                 DataModelId = defaultDatamodel.Id,
                                 DataPointValuesId = dp,
                                 CreatedBy = userId,
                                 LastModifiedBy = userId,
                                 CreatedDate = DateTime.UtcNow,
                                 LastModifiedDate = DateTime.UtcNow,
                                 RowId = rowdim,
                                 ColumnId = null,
                                 CombinationId = null,
                                 State = Domain.Enum.StateEnum.active
                             }).ToList();
                    }

                }
            }
            return defaultDatamodelValues;
        }

        public Task<List<ModelDatapoint>> GetModelDatapointsByOrganizationId(List<long>? datapoints, long organizationId)
        {
            return _context.ModelDatapoints
                .AsNoTracking()
                .Where(a => a.DataModel.OrganizationId == organizationId && datapoints.Contains(a.DatapointValuesId))
                .ToListAsync();
        }
    }
}
