using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ESG.Application.Dto.DataModel.DataModelCreateRequestDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ESG.Application.Services
{
    public class DataModelService : IDataModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ConfiguringModel(ConfiguringDataModelRequestDto configuringDataModelRequestDto)
        {
            if (configuringDataModelRequestDto == null)
            {
                throw new ArgumentNullException(nameof(configuringDataModelRequestDto), "Invalid JSON data");
            }
            var modelConfiguration = new Domain.Models.ModelConfiguration
            {
                DataModelId = configuringDataModelRequestDto.DataModelId,
                ViewType = configuringDataModelRequestDto.ViewType,
                RowId = configuringDataModelRequestDto.RowId,
                ColumnId = configuringDataModelRequestDto.ColumnId,
                State = StateEnum.active,
                CreatedBy = configuringDataModelRequestDto.UserId,
            };
            await _unitOfWork.Repository<Domain.Models.ModelConfiguration>().AddAsync(modelConfiguration);
            var dataModelFilters = configuringDataModelRequestDto.FilterIds
                .Select(filter => new DataModelFilter
                {
                    ModelConfigurationId = modelConfiguration.Id,
                    FilterId = filter,
                    CreatedBy = modelConfiguration.CreatedBy,
                }).ToList();
            foreach (var filter in dataModelFilters)
            {
                modelConfiguration.DataModelFilters = new List<DataModelFilter> { filter };
            }
            await _unitOfWork.Repository<DataModelFilter>().AddRangeAsync(dataModelFilters);
            await _unitOfWork.SaveAsync();
        }
        public async Task CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        {
            if (dataModelCreateRequestDto == null)
                throw new ArgumentNullException(nameof(dataModelCreateRequestDto), "Invalid JSON data");

            if (string.IsNullOrWhiteSpace(dataModelCreateRequestDto.ModelName))
                throw new ArgumentException("Model name cannot be empty");

            if (dataModelCreateRequestDto.CreatedBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var utcNow = DateTime.UtcNow;
            //deleting the old records of DATAMODEL from datamodelvalues, SampleDataModelFiltercomboValues, ModelFilterCombinationalValues
            //-----------------------------------------------------------------------------------------
            
            if (dataModelCreateRequestDto.DataModelId > 0)
            {
                var datapoints = dataModelCreateRequestDto.Datapoints;
                if (datapoints == null)
                {
                    var modelvalues = await _unitOfWork.DataModelRepo.GetDataModelValuesByModelIdOrgId(dataModelCreateRequestDto.DataModelId, dataModelCreateRequestDto.OrganizationId);
                    datapoints = modelvalues?.Select(a => a.DataPointValuesId.Value).ToList();
                }
                var datamodelvalues = await _unitOfWork.DataModelRepo.GetDataModelValuesByDatapointIDsModelIdOrgId
                    (dataModelCreateRequestDto.Datapoints, dataModelCreateRequestDto.DataModelId, dataModelCreateRequestDto.OrganizationId);
                if (datamodelvalues.Count() > 0)
                {
                    throw new SystemException($"the datapoints - {datamodelvalues} need to be removed are alredy having values Or user assigned");
                }
                var list = await _unitOfWork.DataModelRepo.DataModelValuesByModelId(dataModelCreateRequestDto.DataModelId);
                if (list != null)
                {
                    await _unitOfWork.Repository<DataModelValue>().RemoveRangeAsync(list);
                }
                var modelfiltercombinations = await _unitOfWork.DataModelRepo.GetModelFilterCombinations(dataModelCreateRequestDto.DataModelId);
                if (modelfiltercombinations != null)
                {
                    var comboValues = await _unitOfWork.DataModelRepo.GetDataModelCombinationalValuesByModelFilterCombinationIds
                        (modelfiltercombinations.Select(a=>a.Id).ToList());
                    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().RemoveRangeAsync(comboValues);
                    await _unitOfWork.Repository<ModelFilterCombination>().RemoveRangeAsync(modelfiltercombinations);
                }
            }
            var dataModel = new DataModel();
            if (dataModelCreateRequestDto.DataModelId == 0)
            {
                dataModel.OrganizationId = dataModelCreateRequestDto.OrganizationId;
                dataModel.ModelName = dataModelCreateRequestDto.ModelName;
                dataModel.Purpose = dataModelCreateRequestDto.Purpose;
                dataModel.IsDefaultModel = dataModelCreateRequestDto.IsDefault;
                dataModel.CreatedBy = dataModelCreateRequestDto.CreatedBy;
                dataModel.CreatedDate = utcNow;
                dataModel.LastModifiedBy = dataModelCreateRequestDto.CreatedBy;
                dataModel.LastModifiedDate = utcNow;
                dataModel.State = StateEnum.inActive;
                await _unitOfWork.Repository<DataModel>().AddAsync(dataModel);
            }
            else if (dataModelCreateRequestDto.DataModelId > 0)
            {
                dataModel = await _unitOfWork.DataModelRepo.GetDataModelById(dataModelCreateRequestDto.DataModelId);

                if (dataModel == null)
                {
                    throw new SystemException($"DataModel with ID {dataModelCreateRequestDto.DataModelId} not found.");
                }
                dataModel.ModelName = dataModelCreateRequestDto.ModelName;
                dataModel.Purpose = dataModelCreateRequestDto.Purpose;
                dataModel.IsDefaultModel = dataModelCreateRequestDto.IsDefault;
                dataModel.LastModifiedBy = dataModelCreateRequestDto.CreatedBy;
                dataModel.LastModifiedDate = utcNow;
                dataModel.State = StateEnum.inActive;
                await _unitOfWork.Repository<DataModel>().UpdateAsync(dataModel.Id, dataModel);
            }
            await _unitOfWork.SaveAsync();
            var dataModelId = dataModel.Id;
            var modelDatapoints = new List<ModelDatapoint>();

            // Fetch existing ModelDatapoints linked to the model
            //--------------------------------------------------
            
            if (dataModelCreateRequestDto.IsDefault == true)
            {
                var existingModelDatapoints = await _unitOfWork.DataModelRepo
                .GetDatapointsLinkedToDataModel(dataModel.Id, dataModelCreateRequestDto.OrganizationId);
                await _unitOfWork.Repository<ModelDatapoint>().RemoveRangeAsync(existingModelDatapoints);
            }
            if (dataModelCreateRequestDto.IsDefault == false)
            {
                var existingModelDatapoints = await _unitOfWork.DataModelRepo
                .GetDatapointsLinkedToDataModel(dataModel.Id, dataModelCreateRequestDto.OrganizationId);
                var newDatapoints = dataModelCreateRequestDto.Datapoints
                    .Except(existingModelDatapoints.Select(a => a.DatapointValuesId))
                    .ToList();
                var oldDatapoints = existingModelDatapoints
                    .Where(a => !dataModelCreateRequestDto.Datapoints.Contains(a.DatapointValuesId))
                    .ToList();
                if (oldDatapoints.Count() > 0)
                {
                    var generatedefaultdatamodelvalues = await _unitOfWork.DataModelRepo.GenerateDataModelValues(oldDatapoints.Select(a =>a.DatapointValuesId).ToList(), dataModelCreateRequestDto.OrganizationId, dataModelCreateRequestDto.CreatedBy);
                    await _unitOfWork.Repository<DataModelValue>().AddRangeAsync(generatedefaultdatamodelvalues);
                }
                foreach (var datapointId in newDatapoints)
                {
                    var modeldp = new ModelDatapoint();
                    modeldp.DataModelId = dataModelId;
                    modeldp.DataModelId = dataModelId;
                    modeldp.DatapointValuesId = datapointId;
                    modeldp.State = StateEnum.active;
                    modeldp.CreatedBy = dataModelCreateRequestDto.CreatedBy;
                    modeldp.CreatedDate = utcNow;
                    modeldp.LastModifiedBy = dataModelCreateRequestDto.CreatedBy;
                    modeldp.LastModifiedDate = utcNow;
                    dataModel.ModelDatapoints.Add(modeldp);
                    modelDatapoints.Add(modeldp);
                }
                await _unitOfWork.Repository<ModelDatapoint>().AddRangeAsync(modelDatapoints);
            }
            await _unitOfWork.SaveAsync();
            //ModelDimensionTypes and ModelDimensionValues
            //-------------------------------------------------

            if (dataModelCreateRequestDto.DataModelId == 0)
            {
                await GenerateModelDimensionsAndModelDimensionTypes(dataModelCreateRequestDto, dataModelId);
            }
            else if (dataModelCreateRequestDto.DataModelId > 0)
            {

                var modelDimensionType = new ModelDimensionType();
                var existingModelDimensionTypes = await _unitOfWork.DataModelRepo.GetDimensionTypesByModelIdAndOrgId(dataModelId, dataModelCreateRequestDto.OrganizationId);
                foreach (var dimtype in existingModelDimensionTypes)
                {
                    var list = await _unitOfWork.DataModelRepo.GetDimensionValuesToRemoveByTypeId(dimtype.Id);
                    await _unitOfWork.Repository<ModelDimensionValue>().RemoveRangeAsync(list);
                }
                await _unitOfWork.Repository<ModelDimensionType>().RemoveRangeAsync(existingModelDimensionTypes);
                await GenerateModelDimensionsAndModelDimensionTypes(dataModelCreateRequestDto, dataModelId);
            }

            //ModelConfiguration and DataModelFilters
            //-----------------------------------------------------------
            if (dataModelCreateRequestDto.DataModelId == 0)
            {
                if (dataModelCreateRequestDto.Fact?.RowId != null)
                {
                    await GenerateModelConfigurationsAndDataModelFilters(dataModelCreateRequestDto,dataModelCreateRequestDto.Fact,null, dataModelId);
                }
                if (dataModelCreateRequestDto.Narrative?.RowId != null)
                {
                    await GenerateModelConfigurationsAndDataModelFilters(dataModelCreateRequestDto,null, dataModelCreateRequestDto.Narrative, dataModelId);
                }
            }
            else if (dataModelCreateRequestDto.DataModelId > 0)
            {
                var configurations = await _unitOfWork.DataModelRepo.GetConfigurationViewTypesForDataModel(dataModelCreateRequestDto.DataModelId);
                foreach(var configuration in configurations)
                {
                    var filters = await _unitOfWork.DataModelRepo.GetDataModelFiltersByConfigId(configuration.Id);
                    await _unitOfWork.Repository<DataModelFilter>().RemoveRangeAsync(filters);
                }
                await _unitOfWork.Repository<Domain.Models.ModelConfiguration>().RemoveRangeAsync(configurations);
                if (dataModelCreateRequestDto.Fact?.RowId != null)
                {
                    await GenerateModelConfigurationsAndDataModelFilters(dataModelCreateRequestDto, dataModelCreateRequestDto.Fact, null, dataModelId);
                }
                if (dataModelCreateRequestDto.Narrative?.RowId != null)
                {
                    await GenerateModelConfigurationsAndDataModelFilters(dataModelCreateRequestDto, null, dataModelCreateRequestDto.Narrative, dataModelId);
                }
            }
            await _unitOfWork.SaveAsync();

            //re generating the DataModelValues again
            //--------------------------------------

            var modeldimTypes = await _unitOfWork.DataModelRepo.GetDimensionTypesByModelIdAndOrgId(dataModelId, dataModelCreateRequestDto.OrganizationId);
            if (modeldimTypes == null)
                throw new ArgumentException("Model configurtion not set properly");

            var factRowDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId);
            var narrativeRowDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId);
            var factFilterDimensionTypes = new List<ModelDimensionType>();
            var narrativeFilterDimensionTypes = new List<ModelDimensionType>();
            if (dataModelCreateRequestDto.Fact?.Filters != null)
            {
                factFilterDimensionTypes = modeldimTypes.Where(d => dataModelCreateRequestDto.Fact.Filters.Contains(d.DimensionTypeId)).ToList();
            }
            if (dataModelCreateRequestDto.Narrative?.Filters != null)
            {
                narrativeFilterDimensionTypes = modeldimTypes.Where(d => dataModelCreateRequestDto.Narrative.Filters.Contains(d.DimensionTypeId)).ToList();
            }
            var factLists = new Dictionary<long, List<long>>();
            var narrativeLists = new Dictionary<long, List<long>>();
            foreach (var dimension in dataModelCreateRequestDto.Dimension)
            {
                if (factFilterDimensionTypes.Any(f => f.DimensionTypeId == dimension.TypeId))
                {
                    factLists.Add(dimension.TypeId, dimension.Values.ToList());
                }
                if (narrativeFilterDimensionTypes.Any(f => f.DimensionTypeId == dimension.TypeId))
                {
                    narrativeLists.Add(dimension.TypeId, dimension.Values.ToList());
                }
            }
            //Datapoints desicion
            //------------------------------------------------------------------------------
            var datapointsForDataModelValues = new List<long>();
            if (dataModelCreateRequestDto.IsDefault == true)
            {
                var reminingDatapoints = await _unitOfWork.HierarchyRepo.GetRemainingDatapointsByOrganizationId(dataModelCreateRequestDto.OrganizationId);
                if (reminingDatapoints != null && reminingDatapoints.Count() > 0)
                {
                    datapointsForDataModelValues.AddRange(reminingDatapoints);
                }
            }
            if (dataModelCreateRequestDto.IsDefault == false)
            {
                datapointsForDataModelValues.AddRange(dataModelCreateRequestDto.Datapoints);
            }
            var narrativeDatapoints = await _unitOfWork.DataModelRepo.GetDatapointsByViewType(datapointsForDataModelValues);
            var nonNarrativeDatapoints = datapointsForDataModelValues
                    .Where(dp => !narrativeDatapoints.Contains(dp))
                    .ToList();
            var dataModelValues = new List<DataModelValue>();
            ///setting fact view filters and datamodelvalues for datapoint
            if (dataModelCreateRequestDto.Fact?.RowId != null)
            {
                var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Fact);
                var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                var factFiltersCombinations = new List<List<(long DimensionTypeId, long Value)>>();
                var generatedCombinationsForFactView = new List<ModelFilterCombination>();
                var samplemodelFilterCombinationalValues = new List<SampleModelFilterCombinationValue>();

                if (factLists != null && factLists.Count() != 0)
                {
                    factFiltersCombinations = GetCombinations(factLists);
                    generatedCombinationsForFactView = factFiltersCombinations
                        .Select(combination => new ModelFilterCombination
                        {
                            DataModelId = dataModelId,
                            ViewType = ModelViewTypeEnum.Fact,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        })
                        .ToList();

                    await _unitOfWork.Repository<ModelFilterCombination>().AddRangeAsync(generatedCombinationsForFactView);
                    await _unitOfWork.SaveAsync();
                    for (int i = 0; i < factFiltersCombinations.Count; i++)
                    {
                        var combination = factFiltersCombinations[i];
                        var nonprocessedCombo = generatedCombinationsForFactView[i];
                        long comboId = nonprocessedCombo.Id;
                        var processedCombo = new List<ModelFilterCombination>();
                        foreach (var comboType in combination)
                        {
                            var datamodelFilter = datamodelfilters
                                .Where(a => a.FilterId == comboType.DimensionTypeId && a.ModelConfigurationId == datamodelConfigId)
                                .FirstOrDefault();
                            if (datamodelFilter == null)
                            {
                                throw new ArgumentNullException($"No matching DataModelFilter found for FilterId {comboType.DimensionTypeId} and ModelConfigurationId {datamodelConfigId}.");
                            }

                            samplemodelFilterCombinationalValues.Add( new SampleModelFilterCombinationValue
                            {
                                ModelFilterCombinationsId = comboId,
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = datamodelFilter.Id,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            });
                        }
                        processedCombo.Add(nonprocessedCombo);
                    }
                    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().AddRangeAsync(samplemodelFilterCombinationalValues);
                }

                foreach (var datapoint in nonNarrativeDatapoints)
                {
                    if (!generatedCombinationsForFactView.Any())
                    {
                        var rowDimensions = modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId));

                        var columnDimensions = modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => (long?)v.DimensionsId))
                            .DefaultIfEmpty(null);

                        dataModelValues.AddRange(
                            from rowDimension in rowDimensions
                            from columnDimension in columnDimensions
                            select new DataModelValue
                            {
                                CombinationId = null,
                                RowId = rowDimension,
                                ColumnId = columnDimension,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                DataPointValuesId = datapoint,
                                DataModelId = dataModel.Id,
                            });
                    }
                    if (generatedCombinationsForFactView.Count() != 0)
                    {
                        var rowDimensions = modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId));

                        var columnDimensions = modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => (long?)v.DimensionsId))
                            .DefaultIfEmpty(null);

                        dataModelValues.AddRange(
                            from rowDimension in rowDimensions
                            from columnDimension in columnDimensions
                            from combination in generatedCombinationsForFactView
                            select new DataModelValue
                            {
                                CombinationId = combination.Id,
                                RowId = rowDimension,
                                ColumnId = columnDimension,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                DataPointValuesId = datapoint,
                                DataModelId = dataModel.Id,
                            });
                    }
                }
            }
            if (dataModelCreateRequestDto.Narrative?.RowId != null)
            {
                var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Narrative);
                var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                var generatedCombinationsForNarrativeView = new List<ModelFilterCombination>();
                var narrativeFiltersCombinations = new List<List<(long DimensionTypeId, long Value)>>();
                var samplemodelFilterCombinationalValues = new List<SampleModelFilterCombinationValue>();
                if (narrativeLists != null && narrativeLists.Count() != 0)
                {
                    narrativeFiltersCombinations = GetCombinations(narrativeLists);
                    generatedCombinationsForNarrativeView.AddRange(
                        narrativeFiltersCombinations.Select(combination => new ModelFilterCombination
                        {
                            DataModelId = dataModelId,
                            ViewType = ModelViewTypeEnum.Narrative,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        })
                    );
                    await _unitOfWork.Repository<ModelFilterCombination>().AddRangeAsync(generatedCombinationsForNarrativeView);
                    await _unitOfWork.SaveAsync();
                    for (int i = 0; i < narrativeFiltersCombinations.Count; i++)
                    {
                        var combination = narrativeFiltersCombinations[i];
                        var nonprocessedCombo = generatedCombinationsForNarrativeView[i];
                        long comboId = nonprocessedCombo.Id;
                        var processedCombo = new List<ModelFilterCombination>();
                        foreach (var comboType in combination)
                        {
                            var datamodelFilter = datamodelfilters
                                .Where(a => a.FilterId == comboType.DimensionTypeId && a.ModelConfigurationId == datamodelConfigId)
                                .FirstOrDefault();
                            if (datamodelFilter == null)
                            {
                                throw new ArgumentNullException($"No matching DataModelFilter found for FilterId {comboType.DimensionTypeId} and ModelConfigurationId {datamodelConfigId}.");
                            }
                            samplemodelFilterCombinationalValues.Add(new SampleModelFilterCombinationValue
                            {
                                ModelFilterCombinationsId = comboId,
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = datamodelFilter.Id,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            });
                        }
                        processedCombo.Add(nonprocessedCombo);
                    }
                    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().AddRangeAsync(samplemodelFilterCombinationalValues);
                }
                foreach (var datapoint in narrativeDatapoints)
                {
                    var viewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapoint);
                    if (viewtype == null)
                        throw new ArgumentException($"datapoint view type set to null, expected: {datapoint}");
                    if (generatedCombinationsForNarrativeView.Count() == 0)
                    {
                        dataModelValues.AddRange(
                            modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId))
                                .Select(dimensionId => new DataModelValue
                                {
                                    CombinationId = null,
                                    RowId = dimensionId,
                                    ColumnId = null,
                                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                    CreatedDate = utcNow,
                                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                    LastModifiedDate = utcNow,
                                    DataPointValuesId = datapoint,
                                    DataModelId = dataModel.Id,
                                })
                        );
                    }
                    if (generatedCombinationsForNarrativeView.Count() > 0)
                    {
                        dataModelValues.AddRange(
                            modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId))
                                .SelectMany(dimensionId =>
                                    generatedCombinationsForNarrativeView.Select(combination => new DataModelValue
                                    {
                                        CombinationId = combination.Id,
                                        RowId = dimensionId,
                                        ColumnId = null,
                                        CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                        CreatedDate = utcNow,
                                        LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                        LastModifiedDate = utcNow,
                                        DataPointValuesId = datapoint,
                                        DataModelId = dataModel.Id,
                                    })
                                )
                        );
                    }
                }
            }
            dataModel.State = StateEnum.active;
            await _unitOfWork.Repository<DataModelValue>().AddRangeAsync(dataModelValues);
            await _unitOfWork.Repository<DataModel>().UpdateAsync(dataModel.Id, dataModel);
            if (dataModelCreateRequestDto.IsDefault == false)
            {
                var dmvToRemove = await _unitOfWork.DataModelRepo.GetDefaultDataModelValuesByDatapointIDsOrgId(dataModelCreateRequestDto.Datapoints, dataModelCreateRequestDto.OrganizationId);
                if (dmvToRemove != null)
                    await _unitOfWork.Repository<DataModelValue>().RemoveRangeAsync(dmvToRemove);
            }
            await _unitOfWork.SaveAsync();
        }
        public async Task GenerateModelConfigurationsAndDataModelFilters(
            DataModelCreateRequestDto dataModelCreateRequest,
            FactDTO? factdto,
            NarrativeDTO? narrativedto,
            long modelId)
        {
            dynamic dto = null; 
            if (factdto != null)
            {
                dto = factdto;
            }
            else if (narrativedto != null)
            {
                dto = narrativedto;
            }
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Both FactDTO and NarrativeDTO are null.");
            var modelConfigurations = new ESG.Domain.Models.ModelConfiguration();
            modelConfigurations.DataModelId = modelId;
            modelConfigurations.RowId = dto.RowId;
            modelConfigurations.State = StateEnum.active;
            modelConfigurations.CreatedBy = dataModelCreateRequest.CreatedBy;
            modelConfigurations.CreatedDate = DateTime.UtcNow;
            modelConfigurations.LastModifiedBy = dataModelCreateRequest.CreatedBy;
            modelConfigurations.LastModifiedDate = DateTime.UtcNow;
            if (dto is ESG.Application.Dto.DataModel.DataModelCreateRequestDto.FactDTO)
            {
                modelConfigurations.ColumnId = dto.ColumnId;
                modelConfigurations.ViewType = ModelViewTypeEnum.Fact;
            }
            else if (dto is ESG.Application.Dto.DataModel.DataModelCreateRequestDto.NarrativeDTO)
            {
                modelConfigurations.ViewType = ModelViewTypeEnum.Narrative;
            }
            await _unitOfWork.Repository<Domain.Models.ModelConfiguration>().AddAsync(modelConfigurations);
            //await _unitOfWork.SaveAsync();
            if (modelConfigurations.ViewType == ModelViewTypeEnum.Fact && dataModelCreateRequest.Fact?.Filters != null)
            {
                var modelFilters = new List<DataModelFilter>();
                foreach (var filter in dataModelCreateRequest.Fact.Filters)
                {
                    var modelfilter = new DataModelFilter
                    {
                        ModelConfigurationId = modelConfigurations.Id,
                        FilterId = filter,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequest.CreatedBy,
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = dataModelCreateRequest.CreatedBy,
                        LastModifiedDate = DateTime.UtcNow
                    };
                    modelfilter.ModelConfigurationId = modelConfigurations.Id;
                    modelConfigurations.DataModelFilters.Add(modelfilter);
                    modelFilters.Add(modelfilter);
                }
                await _unitOfWork.Repository<DataModelFilter>().AddRangeAsync(modelFilters);
            }
            if (modelConfigurations.ViewType == ModelViewTypeEnum.Narrative && dataModelCreateRequest.Narrative?.Filters != null)
            {
                var modelFilters = new List<DataModelFilter>();
                foreach (var filter in dataModelCreateRequest.Narrative.Filters)
                {
                    var modelfilter = new DataModelFilter
                    {
                        ModelConfigurationId = modelConfigurations.Id,
                        FilterId = filter,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequest.CreatedBy,
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = dataModelCreateRequest.CreatedBy,
                        LastModifiedDate = DateTime.UtcNow
                    };
                    modelfilter.ModelConfigurationId = modelConfigurations.Id;
                    modelConfigurations.DataModelFilters.Add(modelfilter);
                    modelFilters.Add(modelfilter);
                }
                await _unitOfWork.Repository<DataModelFilter>().AddRangeAsync(modelFilters);
            }
        }


        public async Task GenerateModelDimensionsAndModelDimensionTypes(DataModelCreateRequestDto? dataModelCreateRequestDto, long modelId)
        {
            if (dataModelCreateRequestDto == null || dataModelCreateRequestDto.Dimension == null)
            {
                throw new ArgumentNullException(nameof(dataModelCreateRequestDto), "DataModelCreateRequestDto or its Dimension property cannot be null.");
            }
            var modelDimensionValues = new List<ModelDimensionValue>();
            foreach (var dimensionType in dataModelCreateRequestDto.Dimension)
            {
                var modelDimensionType = new ModelDimensionType
                {
                    DataModelId = modelId,
                    DimensionTypeId = dimensionType.TypeId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = DateTime.UtcNow
                };
                await _unitOfWork.Repository<ModelDimensionType>().AddAsync(modelDimensionType);
                foreach (var dimensionValueId in dimensionType.Values)
                {
                    var modelDimensionValue = new ModelDimensionValue
                    {
                        ModelDimensionTypesId = modelDimensionType.Id,
                        DimensionsId = dimensionValueId,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequestDto.CreatedBy,
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                        LastModifiedDate = DateTime.UtcNow
                    };
                    modelDimensionValue.ModelDimensionTypesId = modelDimensionType.Id;
                    modelDimensionType.ModelDimensionValues.Add(modelDimensionValue);
                    modelDimensionValues.Add(modelDimensionValue);
                }
            }
            if (modelDimensionValues.Any())
            {
                await _unitOfWork.Repository<ModelDimensionValue>().AddRangeAsync(modelDimensionValues);
            }
        }

        public static List<List<(long DimensionTypeId, long Value)>> GetCombinations(Dictionary<long, List<long>> dimensionValues)
        {
            var keys = dimensionValues.Keys.ToList();
            var result = new List<List<(long, long)>>();
            Combine(keys, dimensionValues, 0, new List<(long, long)>(), result);
            return result;
        }

        private static void Combine(List<long> keys,
                                    Dictionary<long, List<long>> dimensionValues,
                                    int index,
                                    List<(long DimensionTypeId, long Value)> currentCombination,
                                    List<List<(long, long)>> result)
        {
            if (index == keys.Count)
            {
                result.Add(new List<(long, long)>(currentCombination));
                return;
            }
            var currentKey = keys[index];
            var values = dimensionValues[currentKey];
            foreach (var value in values)
            {
                currentCombination.Add((currentKey, value));
                Combine(keys, dimensionValues, index + 1, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
        public async Task<IEnumerable<DataModelsResponseDto>> GetDataModelsResponsesByOrgId(long organizationId)
        {
            var responseobj = new List<DataModelsResponseDto>();
            //var hasdefaultmodelvalues = await _unitOfWork.DataModelRepo.CheckIsDefaultdataModelvalues(organizationId);
            var datamodels = await _unitOfWork.DataModelRepo.GetDataModelsIncludingDefaultByOrgId(organizationId, true);
            if (datamodels != null)
            {
                foreach (var datamodel in datamodels)
                {
                    var viewTypes = await _unitOfWork.DataModelRepo.GetConfigurationViewTypesForDataModel(datamodel.Id);
                    var datapoints = await _unitOfWork.DataModelRepo.GetDatapointsLinkedToDataModelWithName(datamodel.Id, organizationId);
                    var editable = await _unitOfWork.DataModelRepo.CheckModelIsEditable(datamodel.Id, organizationId);
                    var response = new DataModelsResponseDto
                    {
                        Id = datamodel.Id,
                        Name = datamodel.ModelName,
                        Purpose = datamodel.Purpose,
                        IsDefault = datamodel.IsDefaultModel,
                        IsEditable = !editable,
                        Datapoints = datapoints,
                        FactView = null,
                        NarrativeView = null
                    };
                    foreach (var viewType in viewTypes)
                    {
                        if (viewType.ViewType == ModelViewTypeEnum.Fact)
                        {
                            response.FactView = new FactViewDto
                            {
                                RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                                ColumnDimension = await GetColumnDimensionDto(datamodel.Id, viewType.ViewType),
                                FilterDimension = await GetFilterDimensionDto(datamodel.Id, viewType.ViewType)
                            };
                        }
                        else if (viewType.ViewType == ModelViewTypeEnum.Narrative)
                        {
                            response.NarrativeView = new NarrativeViewDto
                            {
                                RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                                FilterDimension = await GetFilterDimensionDto(datamodel.Id, viewType.ViewType)
                            };
                        }
                    }
                    responseobj.Add(response);
                }
            }
            return responseobj;
        }
        public async Task<DataModelLinkedtoDatapointResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long organizationId)
        {
            var responseobj = new DataModelLinkedtoDatapointResponseDto();
            var datamodel = await _unitOfWork.DataModelRepo.GetDataModelByDatapointIdAndOrgId(datapointId, organizationId);
            if (datamodel == null)
                throw new ArgumentException("there is no model linked to that datapoint not even a default model");
            var datapointviewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapointId);
            if (datapointviewtype == null)
                throw new ArgumentException("datapoint view type is NULL");
            if (datamodel != null)
            {
                var modelConfigWithViewTypes = await _unitOfWork.DataModelRepo.GetConfigurationViewTypesForDataModel(datamodel.Id);
                responseobj = new DataModelLinkedtoDatapointResponseDto
                {
                    ModelId = datamodel.Id,
                    Name = datamodel.ModelName,
                };
                if (datapointviewtype == false)
                {
                    responseobj.RowDimensionType = await GetRowDimension(datamodel.Id, ModelViewTypeEnum.Fact);
                    responseobj.ColumnDimensionType = await GetColumnDimension(datamodel.Id, ModelViewTypeEnum.Fact);
                    responseobj.FilterDimensionTypes = await GetFilterDimension(datamodel.Id, ModelViewTypeEnum.Fact);

                }
                else if (datapointviewtype == true)
                {
                    responseobj.RowDimensionType = await GetRowDimension(datamodel.Id, ModelViewTypeEnum.Narrative);
                    responseobj.FilterDimensionTypes = await GetFilterDimension(datamodel.Id, ModelViewTypeEnum.Narrative);
                }
            }
            if (responseobj == null)
            {
                return responseobj;
            }
            return responseobj;
        }
        private async Task<DatapointDimensionType> GetRowDimension(long modelId, ModelViewTypeEnum viewType)
        {
            var dimensionType = await _unitOfWork.DataModelRepo.GetRowDimensionTypeIdAndNameFromConfigurationByModelId(modelId, viewType);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, dimensionType.Id);
            var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
            return new DatapointDimensionType
            {
                DimensionTypeId = dimensionType.Id,
                DimensionTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DatapointDimensionValue
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
        }
        private async Task<DatapointDimensionType?> GetColumnDimension(long modelId, ModelViewTypeEnum viewType)
        {
            var dimTypeDto = new DatapointDimensionType();
            var columnId = await _unitOfWork.DataModelRepo.GetColumnIdInModelCnfigurationByModelIdAndViewType(modelId, viewType);
            if (columnId == null)
                return null;

            var dimensionType = await _unitOfWork.DataModelRepo.GetColumnDimensionTypeIdAndNameByDimensionTypeId(columnId!.Value);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, dimensionType.Id);
            var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);

            dimTypeDto = new DatapointDimensionType
            {
                DimensionTypeId = dimensionType.Id,
                DimensionTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DatapointDimensionValue
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
            return dimTypeDto;
        }
        private async Task<List<DatapointDimensionType>?> GetFilterDimension(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var responsedto = new List<DatapointDimensionType>();
            var configurationId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(modelId, viewTypeEnum);
            if (configurationId >= 0 || configurationId != null)
            {
                var filterDimension = await _unitOfWork.DataModelRepo.GetFilterDimensionTypeByConfigurationId(configurationId);
                if (filterDimension == null)
                    return responsedto;
                foreach (var filterdim in filterDimension)
                {
                    var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, filterdim.Id);
                    var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
                    var res = new DatapointDimensionType
                    {
                        DimensionTypeId = filterdim.Id,
                        DimensionTypeName = filterdim.Name,
                        DimensionValues = dimensionValues.Select(dv => new DatapointDimensionValue
                        {
                            DimensionValueId = dv.Id,
                            DimensionValueName = dv.Name
                        }).ToList()
                    };
                    responsedto.Add(res);
                }
            }
            return responsedto;
        }

        public async Task SaveDatapointDataInModel(DataPointValueSavingRequestDto requestDto)
        {
            var datamodel = await _unitOfWork.DataModelRepo.GetDataModelByDatapointIdAndOrgId(requestDto.DatapointId, requestDto.OrganizationId);
            var amendment = await _unitOfWork.DataModelRepo.GetAmendmentById(requestDto.AmendmentId);
            if (amendment?.Id == 0 || amendment == null)
            {
                var amend = new Amendment
                {
                    FilterCombinationId = requestDto.CombinationId,
                    Value = requestDto.AmendmentValue,
                    DatapointId = requestDto.DatapointId,
                    OrganizationId = requestDto.OrganizationId,
                };
                await _unitOfWork.Repository<Amendment>().Add(amend);
            }
            if (amendment?.Id > 0 || amendment != null)
            {
                amendment.Value = requestDto.AmendmentValue;
                await _unitOfWork.Repository<Amendment>().Update(amendment);
            }
            if (datamodel?.IsDefaultModel == true)
            {
                var ids = requestDto.Values.Select(a => a.DataModelValueId).ToList();
                var existingdefaultdatapointvalues = await _unitOfWork.DataModelRepo.GetDefaultDataModelValuesById(ids);
                foreach (var reqobj in requestDto.Values)
                {
                    var existingvalue = existingdefaultdatapointvalues?.Where(a => a.Id == reqobj.DataModelValueId).FirstOrDefault();
                    if (existingvalue != null)
                        existingvalue.Value = reqobj.Value;
                    if (existingvalue == null)
                        throw new System.Exception($"there is no existing datamodelvalue with Id - {reqobj.DataModelValueId}");
                    await SaveFileAsync(reqobj.Files, reqobj.DataModelValueId, requestDto.UserId, true);

                }
                await _unitOfWork.Repository<DataModelValue>().UpdateRange(existingdefaultdatapointvalues);
            }
            if (datamodel?.IsDefaultModel == false)
            {
                var ids = requestDto.Values.Select(a => a.DataModelValueId).ToList();
                var existingdatapointvalues = await _unitOfWork.DataModelRepo.GetDataModelValuesById(ids);
                foreach (var reqobj in requestDto.Values)
                {
                    var existingvalue = existingdatapointvalues?.Where(a => a.Id == reqobj.DataModelValueId).FirstOrDefault();
                    if (existingvalue != null)
                        existingvalue.Value = reqobj.Value;
                    if (existingvalue == null)
                        throw new System.Exception($"there is no existing datamodelvalue with Id - {reqobj.DataModelValueId}");
                    await SaveFileAsync(reqobj.Files, reqobj.DataModelValueId, requestDto.UserId, true);
                }
                await _unitOfWork.Repository<DataModelValue>().UpdateRange(existingdatapointvalues);
            }
            await _unitOfWork.SaveAsync();
        }
        public async Task SaveFileAsync(List<Files>? files, long dataModelValueId, long userId, bool isDefaultModel)
        {
            byte[] fileBytes = null;
            var existingfiles = await _unitOfWork.DataModelRepo.GetUploadedFileData(dataModelValueId, isDefaultModel);
            if (existingfiles != null)
            {
                foreach (var existingfile in existingfiles)
                {
                    await _unitOfWork.Repository<UploadedFile>().DeleteAsync(existingfile);
                }
            }
            if (files.Count > 0)
            {
                var uploadedfiles = new List<UploadedFile>();
                foreach (var file in files)
                {
                    fileBytes = Convert.FromBase64String(file.FormFile);
                    var uploadedFile = new UploadedFile
                    {
                        FileName = file.FileName,
                        FileData = fileBytes,
                        UserId = userId,
                        UploadDate = DateTime.UtcNow.ToLocalTime(),
                        DataModelValueId = dataModelValueId,
                        IsDefaultModel = isDefaultModel
                    };
                    uploadedfiles.Add(uploadedFile);
                }
                await _unitOfWork.Repository<UploadedFile>().AddRangeAsync(uploadedfiles);
            }
        }
        private async Task<DimensionTypeDto> GetRowDimensionDto(long modelId, ModelViewTypeEnum viewType)
        {
            var filterdimresponsedto = new List<DimensionTypeDto>();
            var dimensionType = await _unitOfWork.DataModelRepo.GetRowDimensionTypeIdAndNameFromConfigurationByModelId(modelId, viewType);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, dimensionType.Id);
            var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
            return new DimensionTypeDto
            {
                DimensionTypeId = dimensionType.Id,
                DimensionTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DimensionValueDto
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
        }
        private async Task<DimensionTypeDto?> GetColumnDimensionDto(long modelId, ModelViewTypeEnum viewType)
        {
            var dimTypeDto = new DimensionTypeDto();
            var columnId = await _unitOfWork.DataModelRepo.GetColumnIdInModelCnfigurationByModelIdAndViewType(modelId, viewType);
            if (columnId == null)
                return null;

            var dimensionType = await _unitOfWork.DataModelRepo.GetColumnDimensionTypeIdAndNameByDimensionTypeId(columnId!.Value);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, dimensionType.Id);
            var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);

            dimTypeDto = new DimensionTypeDto
            {
                DimensionTypeId = dimensionType.Id,
                DimensionTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DimensionValueDto
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
            return dimTypeDto;
        }
        private async Task<List<DimensionTypeDto>?> GetFilterDimensionDto(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var responsedto = new List<DimensionTypeDto>();
            var configurationId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(modelId, viewTypeEnum);
            if (configurationId > 0 || configurationId != null)
            {
                var filterDimension = await _unitOfWork.DataModelRepo.GetFilterDimensionTypeByConfigurationId(configurationId);
                if (filterDimension == null)
                {
                    return responsedto;
                }
                foreach (var filterdim in filterDimension)
                {
                    var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, filterdim.Id);
                    var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
                    var res = new DimensionTypeDto
                    {
                        DimensionTypeId = filterdim.Id,
                        DimensionTypeName = filterdim.Name,
                        DimensionValues = dimensionValues.Select(dv => new DimensionValueDto
                        {
                            DimensionValueId = dv.Id,
                            DimensionValueName = dv.Name
                        }).ToList()
                    };
                    responsedto.Add(res);
                }
            }
            return responsedto;
        }

        //private async Task<DatapointMetricResponseDto> GetDatapointMetric(long datapointId, long organizationId)
        //{
        //    var metric = new DatapointMetricResponseDto();
        //    var datapoint = await _unitOfWork.DataModelRepo.GetDatapointMetric(datapointId, organizationId);
        //    metric.Id = datapointId;
        //    if (datapoint == null || string.IsNullOrEmpty(datapoint.Name))
        //        throw new System.Exception($"The data point is null here {datapoint == null} and " +
        //            $"{datapoint?.Name}");
        //    metric.Name = datapoint.Name;
        //    if (datapoint.IsNarrative == true)
        //    {
        //        metric.IsNarrative = true;
        //        metric.MetricId = datapoint.DatapointTypeId!.Value;
        //        metric.MetricCode = "Narrative";
        //    }
        //    else if (datapoint.UnitOfMeasureId != null)
        //    {
        //        metric.IsNarrative = false;
        //        metric.MetricId = datapoint.UnitOfMeasureId!.Value;
        //        metric.MetricCode = datapoint.UnitOfMeasure.Code;
        //    }
        //    else if (datapoint.CurrencyId != null)
        //    {
        //        metric.IsNarrative = false;
        //        metric.MetricId = datapoint.CurrencyId!.Value;
        //        metric.MetricCode = datapoint.Currency.CurrencyCode;
        //    }
        //    else
        //    {
        //        throw new System.Exception("This Datapoint is not set to any unitofmeasure or currency neither set to IsNarrative");
        //    }
        //    return metric;
        //}

        public async Task<DatapointSavedValuesResponseDto> GetDatapointSavedValues(DatapointSavedValuesRequestDto datapointSavedValuesRequestDto)
        {
            var response = new DatapointSavedValuesResponseDto();
            long? ModelFilterCombinationId = null;
            var model = await _unitOfWork.DataModelRepo.GetDataModelById(datapointSavedValuesRequestDto.dataModelId);
            if (model == null)
                return response;
            var datapointViewType = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapointSavedValuesRequestDto.DatapointId);
            var viewtype = ModelViewTypeEnum.Narrative;
            if (datapointViewType == false)
            {
                viewtype = ModelViewTypeEnum.Fact;
            }
            var ModelFilterCombinations = await _unitOfWork.DataModelRepo.GetModelFilterCombinationsByModelIdandDatapointId(model.Id, datapointSavedValuesRequestDto.DatapointId, viewtype);

            foreach (var combination in ModelFilterCombinations)
            {
                var combinationFilters = combination.SampleModelFilterCombinationValues
                    .Select(combinationValue => new
                    {
                        TypeId = combinationValue.DataModelFilters.FilterId,
                        ValueId = combinationValue.DimensionsId
                    })
                    .ToList();
                var inputFilters = datapointSavedValuesRequestDto.SavedDataPointFilters?
                    .Where(filter => filter.TypeId.HasValue && filter.ValueId.HasValue)
                    .Select(filter => new
                    {
                        TypeId = filter.TypeId.Value,
                        ValueId = filter.ValueId.Value
                    })
                    .ToList();
                bool isMatch = combinationFilters.All(combFilter =>
                    inputFilters.Any(inputFilter =>
                        inputFilter.TypeId == combFilter.TypeId &&
                        inputFilter.ValueId == combFilter.ValueId));
                if (isMatch)
                {
                    ModelFilterCombinationId = combination.Id;
                    break;
                }
            }
            var amendment = await _unitOfWork.DataModelRepo.GetExistingAmendment(
                datapointSavedValuesRequestDto.DatapointId, ModelFilterCombinationId, datapointSavedValuesRequestDto.OrganizationId);
            response.AmendmentId = amendment?.Id;
            response.Amendment = amendment?.Value;

            response.CombinationId = ModelFilterCombinationId;
            var datamodelValues = await _unitOfWork.DataModelRepo.GetDataModelValuesByDatapointIdCombinatinalIdAndModelId(ModelFilterCombinationId, datapointSavedValuesRequestDto.DatapointId, model.Id);
            response.DatapointId = datapointSavedValuesRequestDto.DatapointId;
            response.DatapointSavedValues = new List<DatapointSavedValues>();
            foreach (var datamodelValue in datamodelValues)
            {
                var uploadedfiles = await _unitOfWork.DataModelRepo.GetUploadedFileForDataModelValue(datamodelValue.Id, true);
                var filestoshow = new List<SavedFiles>();
                foreach (var uploadedfile in uploadedfiles)
                {
                    string? base64String = null;
                    base64String = Convert.ToBase64String(uploadedfile.FileData);
                    filestoshow.Add(new SavedFiles
                    {
                        FileName = uploadedfile.FileName,
                        FormFile = base64String,
                    });
                }
                response.DatapointSavedValues.Add(new DatapointSavedValues
                {
                    DataModelValueId = datamodelValue.Id,
                    RowId = datamodelValue.RowId,
                    ColumnId = datamodelValue.ColumnId,
                    Value = datamodelValue.Value,
                    IsBlocked = datamodelValue.IsBlocked,
                    ResponsibleUserId = datamodelValue.ResponsibleUserId,
                    Files = filestoshow,
                });
            }
            return response;
        }

        public async Task<GetDataModelValuesForAssigningUsersResponseDto> GetDataModelValuesForAssigningUsers(long ModelId, long organizationId)
        {
            var responsedto = new GetDataModelValuesForAssigningUsersResponseDto();
            var datapointsweneed = new List<long>();
            var isdefaultModel = await _unitOfWork.DataModelRepo.VerifyIsDefaultModel(ModelId);
            var dimensionTypes = await _unitOfWork.DataModelRepo.GetModelDimensionTypesByModelDimTypeId(ModelId, organizationId);
            IEnumerable<(long Id, string Name, long TypeId)> dimensionValues = await _unitOfWork.DataModelRepo.GetModelDimensionValuesByModelDimTypeId(
                dimensionTypes.Select(a => (long?)a.Id).ToList());
            var hierarchyId = await _unitOfWork.HierarchyRepo.GetHierarchyIdByOrgId(organizationId);
            if (isdefaultModel)
            {
                var datapoints = await _unitOfWork.HierarchyRepo.GetDatapointsByHierarchyId(hierarchyId);
                var organizationModeldatapoints = await _unitOfWork.HierarchyRepo.GetDatapointsLinkedToModelByOrganizationId(organizationId);
                datapointsweneed = datapoints.Except(organizationModeldatapoints).ToList();
            }
            else if (!isdefaultModel)
            {
                var modeldatapoints = await _unitOfWork.DataModelRepo.GetDatapointsLinkedToDataModel(ModelId, organizationId);
                datapointsweneed = modeldatapoints.Select(a => a.DatapointValuesId).ToList();
            }
            var dataModelValues = await _unitOfWork.DataModelRepo.GetDefaultDataModelValuesByModelIdAndDatapoints(ModelId, datapointsweneed, organizationId);
            var modelDimenstionTypesWithNames = new List<DataModelDimenstionTypesWithNamesForHeaders>();
            var modelDatamodelValues = new List<DataModelValuesForAssigning>();

            foreach (var dimtype in dimensionTypes) //setting dimensiontypes here
            {
                var modeldimtype = new DataModelDimenstionTypesWithNamesForHeaders
                {
                    TypeId = dimtype.DimensionTypeId,
                    TypeName = dimtype.Name,
                };
                modelDimenstionTypesWithNames.Add(modeldimtype);
            }
            responsedto.DataModelDimenstionTypesWithNames = modelDimenstionTypesWithNames;

            foreach (var datamodelvalue in dataModelValues)
            {
                var dimensionsdto = new List<DimensionalCombinationForDatapoint>();
                var rowDto = dimensionValues
                    .Where(a => a.Id == datamodelvalue.RowId)
                    .Select(a => new DimensionalCombinationForDatapoint
                    {
                        TypeId = a.TypeId,
                        ValueId = a.Id,
                        ValueName = a.Name
                    })
                    .FirstOrDefault();
                var colDto = new DimensionalCombinationForDatapoint();
                if (datamodelvalue?.ColumnId != null && dimensionValues != null)
                {
                    colDto = dimensionValues
                    .Where(a => a.Id == datamodelvalue.ColumnId)
                    .Select(a => new DimensionalCombinationForDatapoint
                    {
                        TypeId = a.TypeId,
                        ValueId = a.Id,
                        ValueName = a.Name
                    })
                    .FirstOrDefault() ?? new DimensionalCombinationForDatapoint();
                }
                var filterDtos = new List<DimensionalCombinationForDatapoint>();
                if (datamodelvalue?.Combination?.SampleModelFilterCombinationValues != null && dimensionValues != null)
                {
                    filterDtos = datamodelvalue.Combination.SampleModelFilterCombinationValues
                        .Where(filterId => dimensionValues.Any(a => a.Id == filterId.DimensionsId))
                        .Select(filterId => dimensionValues.FirstOrDefault(a => a.Id == filterId.DimensionsId))
                        //.Where(filter => filter.Id != null || filter.Id != 0) 
                        .Select(filter => new DimensionalCombinationForDatapoint
                        {
                            TypeId = filter.TypeId,
                            ValueId = filter.Id,
                            ValueName = filter.Name,
                        })
                        .ToList() ?? new List<DimensionalCombinationForDatapoint>();
                }
                if (rowDto != null) dimensionsdto.Add(rowDto);
                if (colDto != null && (colDto.TypeId != null && colDto.TypeId != 0 && colDto.ValueId != null && colDto.ValueId != 0))
                {
                    dimensionsdto.Add(colDto);
                }
                if (filterDtos != null && filterDtos.Any(f => f.TypeId != null && f.TypeId != 0 && f.ValueId != null && f.ValueId != 0))
                {
                    dimensionsdto.AddRange(filterDtos);
                }
                var modelvalue = new DataModelValuesForAssigning
                {
                    DataModelValueId = datamodelvalue.Id,
                    DatapointId = datamodelvalue.DataPointValuesId,
                    DatapointName = datamodelvalue.DataPointValues.ShortText ?? string.Empty,
                    DatapointCode = datamodelvalue.DataPointValues.Code ?? string.Empty,
                    DimensionalCombinationForDatapoint = dimensionsdto,
                    IsBlocked = datamodelvalue.IsBlocked,
                    Accountable = datamodelvalue.AccountableUserId,
                    Responsible = datamodelvalue.ResponsibleUserId
                };
                modelDatamodelValues.Add(modelvalue);
            }
            responsedto.DataModelValuesForAssigning = modelDatamodelValues;
            return responsedto;
        }

        public async Task AssignUsersToDataModelValues(AssigningDataModelValuesToUsersRequestDto assigningDataModelValuesToUsersRequestDto)
        {
            var model = await _unitOfWork.DataModelRepo.GetDataModelById(assigningDataModelValuesToUsersRequestDto.ModelId);
            var updatedDataModelValues = new List<DataModelValue>();
            var createdDataModelValues = new List<DataModelValue>();
            var dataModelValues = await _unitOfWork.DataModelRepo.
                GetDataModelValuesById(assigningDataModelValuesToUsersRequestDto.AssigningUsersDtos.Select(a => a.DataModelValueId).ToList(), assigningDataModelValuesToUsersRequestDto.ModelId, assigningDataModelValuesToUsersRequestDto.OrganizationId);
            foreach (var value in assigningDataModelValuesToUsersRequestDto.AssigningUsersDtos)
            {
                if (value.DataModelValueId > 1)
                {
                    var datamodelvalue = dataModelValues.Where(a => a.Id == value.DataModelValueId).FirstOrDefault();
                    datamodelvalue.AccountableUserId = value.AccountableUserId;
                    datamodelvalue.ResponsibleUserId = value.ResponsibleUserId;
                    datamodelvalue.IsBlocked = value.IsBlocked;
                    datamodelvalue.Inform = value.Inform;
                    datamodelvalue.Consult = value.Consult;
                    updatedDataModelValues.Add(datamodelvalue);
                }
            }
            if (updatedDataModelValues.Count > 0)
            {
                await _unitOfWork.Repository<DataModelValue>().UpdateRange(updatedDataModelValues);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<long>?> GetDatapointsLinkedToDataModel(long dataModelId, long organizationId)
        {
            var list = await _unitOfWork.DataModelRepo.GetDatapointsLinkedToDataModel(dataModelId, organizationId);
            return list.Select(a => a.DatapointValuesId).ToList();
        }

        
    }
    
}


