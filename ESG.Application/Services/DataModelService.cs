using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using ESG.Domain.Entities.DataModels;
using ESG.Domain.Entities.DomainEntities;
using ESG.Domain.Enum;
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
            var modelConfiguration = new Domain.Entities.DataModels.ModelConfiguration
            {
                DataModelId = configuringDataModelRequestDto.DataModelId,
                ViewType = configuringDataModelRequestDto.ViewType,
                RowId = configuringDataModelRequestDto.RowId,
                ColumnId = configuringDataModelRequestDto.ColumnId,
                State = StateEnum.active,
                CreatedBy = configuringDataModelRequestDto.UserId,
            };
            await _unitOfWork.Repository<Domain.Entities.DataModels.ModelConfiguration>().AddAsync(modelConfiguration);
            var dataModelFilters = configuringDataModelRequestDto.FilterIds
                .Select(filter => new DataModelFilters
                {
                    ModelConfigurationId = modelConfiguration.Id,
                    FilterId = filter,
                    CreatedBy = modelConfiguration.CreatedBy,
                }).ToList();
            foreach (var filter in dataModelFilters)
            {
                modelConfiguration.DataModelFilters = new List<DataModelFilters> { filter };
            }
            await _unitOfWork.Repository<DataModelFilters>().AddRange(dataModelFilters);
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

            var dataModel = new ESG.Domain.Entities.DataModels.DataModel
            {
                OrganizationId = dataModelCreateRequestDto.OrganizationId,
                ModelName = dataModelCreateRequestDto.ModelName,
                Purpose = dataModelCreateRequestDto.Purpose,
                IsDefaultModel = false,
                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                CreatedDate = utcNow,
                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                LastModifiedDate = utcNow,
                State = StateEnum.active
            };
            await _unitOfWork.Repository<DataModel>().AddAsync(dataModel);
            await _unitOfWork.SaveAsync();

            var dataModelId = dataModel.Id;
            var modelDatapoints = new List<ModelDatapoints>();
            var modelDimensionTypes = new ModelDimensionTypes();
            var modelDimensionValues = new List<ModelDimensionValues>();
            var modelConfigurations = new ESG.Domain.Entities.DataModels.ModelConfiguration();
            var modelFilters = new List<DataModelFilters>();
            var modelCombinations = new List<ModelCombinations>();
            var modelFilterCombinationalValues = new List<ModelFilterCombinationalValues>();
            var dataModelValues = new List<DataModelValues>();
            foreach (var datapointId in dataModelCreateRequestDto.Datapoints)
            {
                modelDatapoints.Add(new ModelDatapoints
                {
                    DataModelId = dataModelId,
                    DatapointValuesId = datapointId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                });
            }
            foreach (var dimensionType in dataModelCreateRequestDto.Dimensions)
            {
                modelDimensionTypes = new ModelDimensionTypes
                {
                    DataModelId = dataModelId,
                    DimensionTypeId = dimensionType.TypeId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<ModelDimensionTypes>().AddAsync(modelDimensionTypes);
                await _unitOfWork.SaveAsync();
                foreach (var dimensionValueId in dimensionType.Values)
                {
                    modelDimensionValues.Add(new ModelDimensionValues
                    {
                        ModelDimensionTypesId = modelDimensionTypes.Id,
                        DimensionsId = dimensionValueId,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequestDto.CreatedBy,
                        CreatedDate = utcNow,
                        LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                        LastModifiedDate = utcNow
                    });
                }
            }
            if (dataModelCreateRequestDto.Fact.RowId != null && dataModelCreateRequestDto.Fact.ColumnId != null)
            {
                modelConfigurations = new Domain.Entities.DataModels.ModelConfiguration
                {
                    DataModelId = dataModelId,
                    RowId = dataModelCreateRequestDto.Fact.RowId!.Value,
                    ColumnId = dataModelCreateRequestDto.Fact.ColumnId,
                    ViewType = ModelViewTypeEnum.Fact,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<Domain.Entities.DataModels.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
                if (dataModelCreateRequestDto.Fact.Filters != null)
                {
                    foreach (var filters in dataModelCreateRequestDto.Fact.Filters)
                    {
                        modelFilters.Add(new DataModelFilters
                        {
                            ModelConfigurationId = modelConfigurations.Id,
                            FilterId = filters,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        });
                    }
                } 
            }
            if (dataModelCreateRequestDto.Narrative.RowId != null && dataModelCreateRequestDto.Fact.Filters != null)
            {
                modelConfigurations = new Domain.Entities.DataModels.ModelConfiguration
                {
                    DataModelId = dataModelId,
                    RowId = dataModelCreateRequestDto.Narrative.RowId!.Value,
                    ColumnId = null,
                    ViewType = ModelViewTypeEnum.Narrative,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<Domain.Entities.DataModels.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
                if (dataModelCreateRequestDto.Fact.Filters != null)
                {
                    foreach (var filters in dataModelCreateRequestDto.Fact.Filters)
                    {
                        modelFilters.Add(new DataModelFilters
                        {
                            ModelConfigurationId = modelConfigurations.Id,
                            FilterId = filters,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        });
                    }
                }
            }
            await _unitOfWork.Repository<ModelDatapoints>().AddRange(modelDatapoints);
            await _unitOfWork.Repository<ModelDimensionValues>().AddRange(modelDimensionValues);
            await _unitOfWork.Repository<DataModelFilters>().AddRange(modelFilters);
            await _unitOfWork.SaveAsync();

            //getting all dimenstion types and looping through the filters

            var modeldimTypes = await _unitOfWork.DataModelRepo.GetDimensionTypesByModelIdAndOrgId(dataModelId, dataModelCreateRequestDto.OrganizationId);
            if (modeldimTypes == null)
                throw new ArgumentException("Model configurtion not set properly");
            //for fact
            var factRowDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId);
            var factColumnDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId);
            var factFilterDimensionTypes = modeldimTypes.Where(d => dataModelCreateRequestDto.Fact.Filters.Contains(d.DimensionTypeId)).ToList();
            if (factRowDimensionType == null)
                throw new ArgumentException("Fact row configurtion not set properly");
            
            foreach (var datapoint in dataModelCreateRequestDto.Datapoints)
            {
                var viewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapoint);
                if (viewtype == null)
                    throw new ArgumentException($"datapoint view type set to null, expected: {datapoint}");
                if (viewtype  == false)//factview of datapoint
                {
                    var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Fact);
                    var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                    var valueLists = new Dictionary<long, List<long>>();
                    foreach (var dimension in dataModelCreateRequestDto.Dimensions)
                    {
                        if (factFilterDimensionTypes.Any(f => f.DimensionTypeId == dimension.TypeId))
                        {
                            valueLists.Add(dimension.TypeId, dimension.Values.ToList());
                        }
                    }
                    var allCombinations = GetCombinations(valueLists);
                    var modelCombination = new ModelCombinations();
                    foreach (var combination in allCombinations)
                    {
                        modelCombination = new ModelCombinations
                        {
                            DataModelId = dataModelId,
                            DataPointValuesId = datapoint,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        };
                        await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelCombination);
                        await _unitOfWork.SaveAsync();

                        foreach (var comboType in combination)
                        {
                            var datamodelfilter = datamodelfilters
                                .Where(a => a.FilterId == comboType.DimensionTypeId && a.ModelConfigurationId == datamodelConfigId)
                                .FirstOrDefault();
                            if (datamodelfilter == null)
                            {
                                throw new ArgumentNullException($"No matching DataModelFilter found for FilterId {comboType.DimensionTypeId} and ModelConfigurationId {datamodelConfigId}.");
                            }
                            var modelFilterCombinationValue = new ModelFilterCombinationalValues
                            {
                                ModelFilterCombinationsId = modelCombination.Id, 
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = datamodelfilter.Id,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            };
                            modelFilterCombinationalValues.Add(modelFilterCombinationValue);
                        }
                        
                        foreach (var dimensionId in modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            foreach (var columnDimension in modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                            {
                                var dataModelValue = new DataModelValues
                                {
                                    CombinationId = modelCombination.Id,
                                    RowId = dimensionId,
                                    ColumnId = columnDimension == null ? (long?)null : columnDimension,
                                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                    CreatedDate = utcNow,
                                };
                                dataModelValues.Add(dataModelValue);
                            }
                        }
                    }
                    await _unitOfWork.Repository<ModelFilterCombinationalValues>().AddRange(modelFilterCombinationalValues);
                    await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelCombination);
                    await _unitOfWork.SaveAsync();
                }
                if (viewtype == true)
                {
                    var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Fact);
                    var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                    var valueLists = new Dictionary<long, List<long>>();
                    foreach (var dimension in dataModelCreateRequestDto.Dimensions)
                    {
                        if (factFilterDimensionTypes.Any(f => f.DimensionTypeId == dimension.TypeId))
                        {
                            valueLists.Add(dimension.TypeId, dimension.Values.ToList());
                        }
                    }
                    var allCombinations = GetCombinations(valueLists);
                    foreach (var combination in allCombinations)
                    {
                        var modelCombination = new ModelCombinations
                        {
                            DataModelId = dataModelId,
                            DataPointValuesId = datapoint,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        };
                        await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelCombination);
                        await _unitOfWork.SaveAsync();

                        foreach (var comboType in combination)
                        {
                            var datamodelfilterId = datamodelfilters.Where(a => a.FilterId == comboType.DimensionTypeId);
                            var modelFilterCombinationValue = new ModelFilterCombinationalValues
                            {
                                ModelFilterCombinationsId = modelCombination.Id,
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = comboType.DimensionTypeId,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            };
                            modelFilterCombinationalValues.Add(modelFilterCombinationValue);
                        }
                        await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelCombination);
                        await _unitOfWork.SaveAsync();
                        foreach (var dimensionId in modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            var dataModelValue = new DataModelValues
                            {
                                CombinationId = modelCombination.Id,
                                RowId = dimensionId,
                                ColumnId = null,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                            };
                            dataModelValues.Add(dataModelValue);
                        }
                        await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelCombination);
                       
                    }
                }
                await _unitOfWork.SaveAsync();
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
            var datamodels = await _unitOfWork.DataModelRepo.GetDataModelsIncludingDefaultByOrgId(organizationId);
            if (datamodels != null)
            {
                foreach (var datamodel in datamodels)
                {
                    var viewTypes = await _unitOfWork.DataModelRepo.GetConfigurationViewTypesForDataModel(datamodel.Id);
                    var response = new DataModelsResponseDto
                    {
                        Id = datamodel.Id,
                        Name = datamodel.ModelName,
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
                                ColumnDimension = await GetColumnDimensionDto(datamodel.Id,viewType.ViewType),
                                FilterDimension = await GetFilterDimensionsDto(datamodel.Id, viewType.ViewType)
                            };
                        }
                        else if (viewType.ViewType == ModelViewTypeEnum.Narrative)
                        {
                            response.NarrativeView = new NarrativeViewDto
                            {
                                RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                                FilterDimension = await GetFilterDimensionsDto(datamodel.Id, viewType.ViewType)
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
            var datamodel = await _unitOfWork.DataModelRepo.GetDataModelIdByDatapointIdAndOrgId(datapointId, organizationId);
            if (datamodel == null)
                throw new ArgumentException("there is no model linked to that datapoint");
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
                    responseobj.FilterDimensionTypes = await GetFilterDimensions(datamodel.Id, ModelViewTypeEnum.Fact);
                    
                }
                else if (datapointviewtype == true)
                {

                    responseobj.RowDimensionType = await GetRowDimension(datamodel.Id, ModelViewTypeEnum.Narrative);
                    responseobj.FilterDimensionTypes = await GetFilterDimensions(datamodel.Id, ModelViewTypeEnum.Narrative);
                } 
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
                DimensionsTypeName = dimensionType.Name,
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
                DimensionsTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DatapointDimensionValue
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
            return dimTypeDto;
        }
        private async Task<List<DatapointDimensionType>?> GetFilterDimensions(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var responsedto = new List<DatapointDimensionType>();
            var configurationId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(modelId, viewTypeEnum);
            if (configurationId >= 0 || configurationId != null)
            {
                var filterDimensions = await _unitOfWork.DataModelRepo.GetFilterDimensionTypeByConfigurationId(configurationId);
                foreach (var filterdim in filterDimensions)
                {
                    var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, filterdim.Id);
                    var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
                    var res = new DatapointDimensionType
                    {
                        DimensionTypeId = filterdim.Id, 
                        DimensionsTypeName = filterdim.Name, 
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

        public async Task SaveDatapointDataInModel(DataPointValuesSavingRequestDto requestdto)
        {
            if (requestdto == null)
                throw new ArgumentNullException(nameof(requestdto), "Invalid JSON data");

            if (long.IsNegative(requestdto.ModelId))
                throw new ArgumentException("Model name cannot be empty");
            var utcNow = DateTime.UtcNow;

            var modelCombinations = await _unitOfWork.DataModelRepo.GetModelCombinationsByModelIdandDatapointId(requestdto.ModelId, requestdto.DatapointId);
            if (modelCombinations == null || !modelCombinations.Any())
            {
                await SaveDatamodelData(requestdto);
                await _unitOfWork.SaveAsync();
                return;
            }
            foreach (var combination in modelCombinations)
            {
                var isMatch = combination.ModelFilterCombinationalValues.All(combinationValue =>
                    requestdto.FilterDtos.Any(inputFilter =>
                       // inputFilter.TypeId == combinationValue.DataModelFilters.FilterId &&
                        inputFilter.ValueId == combinationValue.DimensionsId));

                if (isMatch)
                {
                    var modelCombinationId = combination.Id;

                    var existingDatapointData = await _unitOfWork.DataModelRepo.GetDataModelValuesByCombinationId(modelCombinationId);
                    var updatedValues = new List<DataModelValues>();

                    foreach (var value in existingDatapointData)
                    {
                        var matchingFilter = requestdto.DataDtos.FirstOrDefault(filter =>
                            filter.RowId == value.RowId && filter.ColumnId == value.ColumnId);

                        if (matchingFilter != null)
                        {
                            value.Value = matchingFilter.Value;
                            value.LastModifiedBy = requestdto.UserId;
                            value.LastModifiedDate = utcNow;
                            updatedValues.Add(value);
                        }
                    }

                    if (updatedValues.Any())
                    {
                        await _unitOfWork.Repository<DataModelValues>().UpdateRange(updatedValues);
                    }
                }
                else
                {
                    await SaveDatamodelData(requestdto);
                }
            }
            await _unitOfWork.SaveAsync();
        }

        private async Task SaveDatamodelData(DataPointValuesSavingRequestDto requestdto)
        {
            var utcNow = DateTime.UtcNow;
            var modelcombination = new ModelCombinations();
            var modelFilterCombinationalValues = new List<ModelFilterCombinationalValues>();
            var dataModelValues = new List<DataModelValues>();
            if (requestdto.ModelId != 0)
            {
                var datapointviewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(requestdto.DatapointId);
                if (datapointviewtype == null)
                    throw new ArgumentException("datapoint view type is NULL");
                if (datapointviewtype != null && datapointviewtype == false)
                {
                    var modelConfiguration = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(requestdto.ModelId, ModelViewTypeEnum.Fact);
                    var modelFilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(modelConfiguration);

                    modelcombination = new ModelCombinations
                    {
                        DataModelId = requestdto.ModelId,
                        DataPointValuesId = requestdto.DatapointId,
                        CreatedBy = requestdto.UserId,
                        CreatedDate = utcNow,
                        LastModifiedBy = requestdto.UserId,
                        LastModifiedDate = utcNow,
                        State = StateEnum.active
                    };
                    await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelcombination);
                    await _unitOfWork.SaveAsync();
                    foreach (var reqfilter in requestdto.FilterDtos)
                    {
                        var matchingFilter = modelFilters.FirstOrDefault(filter => filter.FilterId == reqfilter.TypeId);
                        if (matchingFilter != null)
                        {
                            modelFilterCombinationalValues.Add(new ModelFilterCombinationalValues
                            {
                                ModelFilterCombinationsId = modelcombination.Id,
                                DataModelFiltersId = matchingFilter.Id,
                                DimensionsId = reqfilter.ValueId,
                                CreatedBy = requestdto.UserId,
                                CreatedDate = utcNow,
                                LastModifiedBy = requestdto.UserId,
                                LastModifiedDate = utcNow,
                                State = StateEnum.active
                            });
                        }
                    }
                    foreach (var values in requestdto.DataDtos)
                    {
                        dataModelValues.Add(new DataModelValues
                        {
                            RowId = values.RowId,
                            ColumnId = values.ColumnId,
                            CombinationId = modelcombination.Id,
                            Value = values.Value,
                            CreatedBy = requestdto.UserId,
                            CreatedDate = utcNow,
                            LastModifiedBy = requestdto.UserId,
                            LastModifiedDate = utcNow,
                            State = StateEnum.active
                        });
                    }
                }
                else if (datapointviewtype != null && datapointviewtype == true)
                {
                    var modelConfiguration = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(requestdto.ModelId, ModelViewTypeEnum.Narrative);
                    var modelFilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(modelConfiguration);
                    modelcombination = new ModelCombinations
                    {
                        DataModelId = requestdto.ModelId,
                        DataPointValuesId = requestdto.DatapointId,
                        CreatedBy = requestdto.UserId,
                        CreatedDate = utcNow,
                        LastModifiedBy = requestdto.UserId,
                        LastModifiedDate = utcNow,
                        State = StateEnum.active
                    };
                    await _unitOfWork.Repository<ModelCombinations>().AddAsync(modelcombination);
                    await _unitOfWork.SaveAsync();
                    foreach (var reqfilter in requestdto.FilterDtos)
                    {
                        var matchingFilter = modelFilters.FirstOrDefault(filter => filter.FilterId == reqfilter.TypeId);
                        if (matchingFilter != null)
                        {
                            modelFilterCombinationalValues.Add(new ModelFilterCombinationalValues
                            {
                                ModelFilterCombinationsId = modelcombination.Id,
                                DataModelFiltersId = matchingFilter.Id,
                                DimensionsId = reqfilter.ValueId,
                                CreatedBy = requestdto.UserId,
                                CreatedDate = utcNow,
                                LastModifiedBy = requestdto.UserId,
                                LastModifiedDate = utcNow,
                                State = StateEnum.active
                            });
                        }
                    }
                    foreach (var values in requestdto.DataDtos)
                    {
                        dataModelValues.Add(new DataModelValues
                        {
                            RowId = values.RowId,
                            ColumnId = null,
                            CombinationId = modelcombination.Id,
                            Value = values.Value,
                            CreatedBy = requestdto.UserId,
                            CreatedDate = utcNow,
                            LastModifiedBy = requestdto.UserId,
                            LastModifiedDate = utcNow,
                            State = StateEnum.active
                        });
                    }
                }
            }
            await _unitOfWork.Repository<ModelFilterCombinationalValues>().AddRange(modelFilterCombinationalValues);
            await _unitOfWork.Repository<DataModelValues>().AddRange(dataModelValues);
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
                DimensionsTypeName = dimensionType.Name,
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
                DimensionsTypeName = dimensionType.Name,
                DimensionValues = dimensionValues.Select(dv => new DimensionValueDto
                {
                    DimensionValueId = dv.Id,
                    DimensionValueName = dv.Name
                }).ToList()
            };
            return dimTypeDto;
        }
        private async Task<List<DimensionTypeDto>?> GetFilterDimensionsDto(long modelId, ModelViewTypeEnum viewTypeEnum)
        {
            var responsedto = new List<DimensionTypeDto>();
            var configurationId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(modelId, viewTypeEnum);
            if (configurationId >= 0 || configurationId != null)
            {
                var filterDimensions = await _unitOfWork.DataModelRepo.GetFilterDimensionTypeByConfigurationId(configurationId);
                foreach (var filterdim in filterDimensions)
                {
                    var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(modelId, filterdim.Id);
                    var dimensionValues = await _unitOfWork.DataModelRepo.GetDimensionValuesByTypeId(modelDimensionTypeId);
                    var res = new DimensionTypeDto
                    {
                        DimensionTypeId = filterdim.Id,
                        DimensionsTypeName = filterdim.Name,
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

        public async Task<DatapointMetricResponseDto> GetDatapointMetric(long datapointId, long organizationId)
        {
            var metric = new DatapointMetricResponseDto();
            var datapoint = await _unitOfWork.DataModelRepo.GetDatapointMetric(datapointId, organizationId);
            metric.Id = datapointId;
            metric.Name = datapoint.Name;
            if (datapoint.IsNarrative == true)
            {
                metric.IsNarrative = true;
                metric.MetricId = datapoint.DatapointTypeId!.Value;
                metric.MetricCode = datapoint.DataPointType.Code;
            }
            else if (datapoint.UnitOfMeasureId != null)
            {
                metric.IsNarrative = false;
                metric.MetricId = datapoint.UnitOfMeasureId!.Value;
                metric.MetricCode = datapoint.UnitOfMeasure.Code;
            }
            else if (datapoint.UnitOfMeasureId == null)
            {
                metric.IsNarrative = false;
                metric.MetricId = datapoint.CurrencyId!.Value;
                metric.MetricCode = datapoint.Currency.CurrencyCode;
            }
            return metric;
        }

        public async Task<DatapointSavedValuesResponseDto> GetDatapointSavedValues(DatapointSavedValuesRequestDto datapointSavedValuesRequestDto)
        {
            var response = new DatapointSavedValuesResponseDto();
            long modelCombinationId = 0;
            bool isMatch = false;
            var modelId = await _unitOfWork.DataModelRepo.GetDataModelIdByDatapointIdAndOrgId(datapointSavedValuesRequestDto.DatapointId, datapointSavedValuesRequestDto.OrganizatonId);
            if (modelId == null)
                throw new ArgumentNullException("There is no model linked to datapoint");

            var modelCombinations = await _unitOfWork.DataModelRepo.GetModelCombinationsByModelIdandDatapointId(modelId.Id, datapointSavedValuesRequestDto.DatapointId);
            if (modelCombinations == null || !modelCombinations.Any())
                throw new ArgumentNullException("there are no combinations present for that datapoinr");
            if (datapointSavedValuesRequestDto.SavedDataPointFilters == null || !datapointSavedValuesRequestDto.SavedDataPointFilters.Any())
            {
                throw new ArgumentException("No filters provided in the request.");
            }
            foreach (var combination in modelCombinations)
            {
                isMatch = combination.ModelFilterCombinationalValues.All(combinationValue =>
                datapointSavedValuesRequestDto.SavedDataPointFilters.Any(inputFilter =>
                //inputFilter.TypeId == combinationValue.DataModelFilters.FilterId &&  
                inputFilter.ValueId == combinationValue.DimensionsId));
                if (isMatch)
                {
                    modelCombinationId = combination.Id;
                    break;
                }
                if (!isMatch)
                    throw new InvalidOperationException("No matching model filter combination Values found with ");
            }
            
            var datamodelValues = await _unitOfWork.DataModelRepo.GetDataModelValuesByCombinationId(modelCombinationId);
            var datapointdetails = await GetDatapointMetric(datapointSavedValuesRequestDto.DatapointId, datapointSavedValuesRequestDto.OrganizatonId);
            response.DatapointId = datapointSavedValuesRequestDto.DatapointId;
            response.Name = datapointdetails.Name;
            response.UOMCode = datapointdetails.MetricCode;
            response.IsNarrative = datapointdetails.IsNarrative;
            response.DatapointSavedValues = new List<DatapointSavedValues>();
            foreach (var datamodelValue in datamodelValues)
            {
                response.DatapointSavedValues.Add(new DatapointSavedValues
                {
                    RowId = datamodelValue.RowId,
                    ColumnId = datamodelValue.ColumnId,
                    Value = datamodelValue.Value,
                });
            }
            return response;
        }
    }
}
