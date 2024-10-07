using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;
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
            await _unitOfWork.Repository<DataModelFilter>().AddRange(dataModelFilters);
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

            var dataModel = new ESG.Domain.Models.DataModel
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
            var modelDatapoints = new List<ModelDatapoint>();
            var modelDimensionTypes = new ModelDimensionType();
            var modelDimensionValues = new List<ModelDimensionValue>();
            var modelConfigurations = new ESG.Domain.Models.ModelConfiguration();
            var modelFilters = new List<DataModelFilter>();
            
            foreach (var datapointId in dataModelCreateRequestDto.Datapoints)
            {
                modelDatapoints.Add(new ModelDatapoint
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
            foreach (var dimensionType in dataModelCreateRequestDto.Dimension)
            {
                modelDimensionTypes = new ModelDimensionType
                {
                    DataModelId = dataModelId,
                    DimensionTypeId = dimensionType.TypeId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<ModelDimensionType>().AddAsync(modelDimensionTypes);
                await _unitOfWork.SaveAsync();
                foreach (var dimensionValueId in dimensionType.Values)
                {
                    modelDimensionValues.Add(new ModelDimensionValue
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
            if (dataModelCreateRequestDto.Fact.RowId != null)
            {
                modelConfigurations = new Domain.Models.ModelConfiguration
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
                await _unitOfWork.Repository<Domain.Models.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
                if (dataModelCreateRequestDto.Fact.Filters != null)
                {
                    foreach (var filters in dataModelCreateRequestDto.Fact.Filters)
                    {
                        modelFilters.Add(new DataModelFilter
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
            if (dataModelCreateRequestDto.Narrative.RowId != null )
            {
                modelConfigurations = new Domain.Models.ModelConfiguration
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
                await _unitOfWork.Repository<Domain.Models.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
                if (dataModelCreateRequestDto.Narrative.Filters != null)
                {
                    foreach (var filters in dataModelCreateRequestDto.Narrative.Filters)
                    {
                        modelFilters.Add(new DataModelFilter
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
            await _unitOfWork.Repository<ModelDatapoint>().AddRange(modelDatapoints);
            await _unitOfWork.Repository<ModelDimensionValue>().AddRange(modelDimensionValues);
            await _unitOfWork.Repository<DataModelFilter>().AddRange(modelFilters);

            await _unitOfWork.SaveAsync();

            //getting all dimenstion types and looping through the filters

            var modeldimTypes = await _unitOfWork.DataModelRepo.GetDimensionTypesByModelIdAndOrgId(dataModelId, dataModelCreateRequestDto.OrganizationId);
            if (modeldimTypes == null)
                throw new ArgumentException("Model configurtion not set properly");

            var factRowDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId);
            var narrativeRowDimensionType = modeldimTypes.FirstOrDefault(d => d.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId);
            if (factRowDimensionType == null || narrativeRowDimensionType == null)
                throw new ArgumentException("Row configurtion not set properly");

            var factFilterDimensionTypes = new List<ModelDimensionType>();
            var narrativeFilterDimensionTypes = new List<ModelDimensionType>();
            if (dataModelCreateRequestDto.Fact.Filters != null)
            {
                factFilterDimensionTypes = modeldimTypes.Where(d => dataModelCreateRequestDto.Fact.Filters.Contains(d.DimensionTypeId)).ToList();
            }
            if (dataModelCreateRequestDto.Narrative.Filters != null)
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
            var narrativeDatapoints = await _unitOfWork.DataModelRepo.GetDatapointsByViewType(dataModelCreateRequestDto.Datapoints);
            ///setting fact view filters and datamodelvalues for datapoint
            if (dataModelCreateRequestDto.Fact != null)
            {
                var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Fact);
                var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                var factFiltersCombinations = new List<List<(long DimensionTypeId, long Value)>>();
                var generatedCombinationsForFactView = new List<ModelFilterCombination>();
                var samplemodelFilterCombinationalValues = new List<SampleModelFilterCombinationValue>();
                var dataModelValues = new List<DataModelValue>();
                if (factLists != null && factLists.Count() != 0)
                {
                    factFiltersCombinations = GetCombinations(factLists);
                    foreach (var combination in factFiltersCombinations)
                    {
                        var ModelFilterCombination = new ModelFilterCombination
                        {
                            DataModelId = dataModelId,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        };
                        generatedCombinationsForFactView.Add(ModelFilterCombination);
                    }

                    await _unitOfWork.Repository<ModelFilterCombination>().AddRange(generatedCombinationsForFactView);
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

                            var sampleModelFilterCombinationValue = new SampleModelFilterCombinationValue
                            {
                                ModelFilterCombinationsId = comboId,
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = datamodelFilter.Id,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            };

                            samplemodelFilterCombinationalValues.Add(sampleModelFilterCombinationValue);
                        }
                        processedCombo.Add(nonprocessedCombo);
                    }

                    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().AddRange(samplemodelFilterCombinationalValues);
                }
                var nonNarrativeDatapoints = dataModelCreateRequestDto.Datapoints
                    .Where(dp => !narrativeDatapoints.Contains(dp))
                    .ToList();
                foreach (var datapoint in nonNarrativeDatapoints)
                {
                    //var viewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapoint);
                    //if (viewtype == null)
                    //    throw new ArgumentException($"datapoint view type set to null, expected: {datapoint}");
                    if (generatedCombinationsForFactView.Count() == 0)
                    {
                        foreach (var dimensionId in modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            foreach (var columnDimension in modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                            {
                                var dataModelValue = new DataModelValue
                                {
                                    CombinationId = null,
                                    RowId = dimensionId,
                                    ColumnId = columnDimension == null ? (long?)null : columnDimension,
                                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                    CreatedDate = utcNow,
                                    DataPointValuesId = datapoint,
                                    DataModelId = dataModel.Id,
                                };
                                dataModelValues.Add(dataModelValue);
                            }
                        }
                    }
                    if (generatedCombinationsForFactView.Count() != 0)
                    {
                        foreach (var dimensionId in modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.RowId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            foreach (var columnDimension in modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Fact.ColumnId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                            {
                                foreach (var combination in generatedCombinationsForFactView)
                                {
                                    var dataModelValue = new DataModelValue
                                    {
                                        CombinationId = combination.Id,
                                        RowId = dimensionId,
                                        ColumnId = columnDimension == null ? (long?)null : columnDimension,
                                        CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                        CreatedDate = utcNow,
                                        DataPointValuesId = datapoint,
                                        DataModelId = dataModel.Id,
                                    };
                                    dataModelValues.Add(dataModelValue);
                                }

                            }
                        }
                    }
                }
                
                await _unitOfWork.Repository<DataModelValue>().AddRange(dataModelValues);
                await _unitOfWork.SaveAsync();
            }
            if (dataModelCreateRequestDto.Narrative != null)
            {
                var datamodelConfigId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(dataModelId, ModelViewTypeEnum.Narrative);
                var datamodelfilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(datamodelConfigId);
                var generatedCombinationsForNarrativeView = new List<ModelFilterCombination>();
                var narrativeFiltersCombinations = new List<List<(long DimensionTypeId, long Value)>>();
                var samplemodelFilterCombinationalValues = new List<SampleModelFilterCombinationValue>();
                var dataModelValues = new List<DataModelValue>();

                if (narrativeLists != null && narrativeLists.Count() != 0)
                {
                    narrativeFiltersCombinations = GetCombinations(narrativeLists);
                    foreach (var combination in narrativeFiltersCombinations)
                    {
                        var ModelFilterCombination = new ModelFilterCombination
                        {
                            DataModelId = dataModelId,
                            State = StateEnum.active,
                            CreatedBy = dataModelCreateRequestDto.CreatedBy,
                            CreatedDate = utcNow,
                            LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                            LastModifiedDate = utcNow
                        };
                        generatedCombinationsForNarrativeView.Add(ModelFilterCombination);
                    }
                    await _unitOfWork.Repository<ModelFilterCombination>().AddRange(generatedCombinationsForNarrativeView);
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

                            var sampleModelFilterCombinationValue = new SampleModelFilterCombinationValue
                            {
                                ModelFilterCombinationsId = comboId, 
                                DimensionsId = comboType.Value,
                                DataModelFiltersId = datamodelFilter.Id,
                                State = StateEnum.active,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                                LastModifiedDate = utcNow
                            };
                            samplemodelFilterCombinationalValues.Add(sampleModelFilterCombinationValue);
                        }
                        processedCombo.Add(nonprocessedCombo);
                    }

                    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().AddRange(samplemodelFilterCombinationalValues);
                }
                foreach (var datapoint in narrativeDatapoints)
                {
                    var viewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(datapoint);
                    if (viewtype == null)
                        throw new ArgumentException($"datapoint view type set to null, expected: {datapoint}");
                    if (generatedCombinationsForNarrativeView.Count() == 0)
                    {
                        foreach (var dimensionId in modeldimTypes
                            .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId)
                            .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            var dataModelValue = new DataModelValue
                            {
                                CombinationId = null,
                                RowId = dimensionId,
                                ColumnId = null,
                                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                CreatedDate = utcNow,
                                DataPointValuesId = datapoint,
                                DataModelId = dataModel.Id,
                            };
                            dataModelValues.Add(dataModelValue);
                        }
                    }
                    if (generatedCombinationsForNarrativeView.Count() > 0)
                    {
                        foreach (var dimensionId in modeldimTypes
                                .Where(a => a.DimensionTypeId == dataModelCreateRequestDto.Narrative.RowId)
                                .SelectMany(a => a.ModelDimensionValues.Select(v => v.DimensionsId)))
                        {
                            foreach (var combination in generatedCombinationsForNarrativeView)
                            {
                                var dataModelValue = new DataModelValue
                                {
                                    CombinationId = combination.Id,
                                    RowId = dimensionId,
                                    ColumnId = null,
                                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                                    CreatedDate = utcNow,
                                    DataPointValuesId = datapoint,
                                    DataModelId = dataModel.Id,
                                };
                                dataModelValues.Add(dataModelValue);
                            }
                        }
                    }
                }
                
                await _unitOfWork.Repository<DataModelValue>().AddRange(dataModelValues);
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
                    responseobj.FilterDimensionTypes = await GetFilterDimension(datamodel.Id, ModelViewTypeEnum.Fact);
                    
                }
                else if (datapointviewtype == true)
                {
                    responseobj.RowDimensionType = await GetRowDimension(datamodel.Id, ModelViewTypeEnum.Narrative);
                    responseobj.FilterDimensionTypes = await GetFilterDimension(datamodel.Id, ModelViewTypeEnum.Narrative);
                } 
            }
            if (responseobj ==null)
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
            var datapointViewType = await _unitOfWork.DataModelRepo.GetDatapointViewType(requestDto.DatapointId);
            if (datapointViewType == null)
                throw new ArgumentNullException($"Datapoint Id {requestDto.DatapointId} viewtype is set to null");
            var modelconfiguration = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType
                (requestDto.ModelId, (datapointViewType == true) ? ModelViewTypeEnum.Narrative : ModelViewTypeEnum.Fact);
            if (requestDto.FilterDtos != null || requestDto.FilterDtos.Count() != 0)
            {
                var modelCombinations = await _unitOfWork.DataModelRepo.GetModelFilterCombinations(requestDto.ModelId);
                //var datamodelfilters = await _unitOfWork.DataModelRepo.GetDataModelFiltersByConfigId(modelconfiguration);
                var filterDtoValueIds = requestDto.FilterDtos.Select(fd => fd.ValueId).ToList();
                var samplefiltercombinationalValues = await _unitOfWork.DataModelRepo.GetDataModelCombinationalValuesByModelFilterCombinationIds(modelCombinations);
                var matchingCombinations = new List<SampleModelFilterCombinationValue>();
                foreach (var combination in modelCombinations)
                {
                    var combinationValues = samplefiltercombinationalValues.Where(a => a.ModelFilterCombinationsId == combination).ToList();
                    var combinationDimensions = combinationValues.Select(a => a.DimensionsId).ToList();
                    if (filterDtoValueIds.SequenceEqual(combinationDimensions))
                    {
                        matchingCombinations = combinationValues;
                    }

                }
                var combinationId = matchingCombinations.Select(a => a.ModelFilterCombinationsId).FirstOrDefault();
                if (combinationId == null)
                {
                    throw new ArgumentNullException("No matching combination found for the given filters.");
                }
                var rowIds = requestDto.DataDtos.Select(d => d.RowId).ToList();
                var columnIds = requestDto.DataDtos.Select(d => d.ColumnId).ToList();
                var existingDataModelValues = await _unitOfWork.DataModelRepo.GetDataModelValues(requestDto.ModelId,requestDto.DatapointId, rowIds, columnIds, combinationId);
                foreach (var dataDto in requestDto.DataDtos)
                {
                    var existingValue = existingDataModelValues.FirstOrDefault(dmv =>
                        dmv.RowId == dataDto.RowId && dmv.ColumnId == dataDto.ColumnId);

                    if (existingValue != null)
                    {
                        existingValue.Value = dataDto.Value;
                        await _unitOfWork.Repository<DataModelValue>().Update(existingValue);
                    }
                    else
                    {
                        throw new SystemException($"no such row column combination found for row - {dataDto.RowId} and column - {dataDto.ColumnId}");
                    }
                }
                var amendment = new Amendment();
                var existingAmendment = await _unitOfWork.DataModelRepo.GetExistingAmendment(requestDto.DatapointId, combinationId);
                if (existingAmendment != null)
                {
                    existingAmendment.Value = requestDto.Amendment;
                    await _unitOfWork.Repository<Amendment>().Update(existingAmendment);
                }
                else
                {
                    amendment.DatapointId = requestDto.DatapointId;
                    amendment.FilterCombinationId = combinationId;
                    amendment.Value = requestDto.Amendment;
                    await _unitOfWork.Repository<Amendment>().Add(amendment);
                }
            }
            else
            {
                var rowIds = requestDto.DataDtos.Select(d => d.RowId).ToList();
                var columnIds = requestDto.DataDtos.Select(d => d.ColumnId).ToList();
                var existingDataModelValues = await _unitOfWork.DataModelRepo.GetDataModelValues(requestDto.ModelId, requestDto.DatapointId, rowIds, columnIds, null);
                foreach (var dataDto in requestDto.DataDtos)
                {
                    var existingValue = existingDataModelValues.FirstOrDefault(dmv =>
                        dmv.RowId == dataDto.RowId && dmv.ColumnId == dataDto.ColumnId);

                    if (existingValue != null)
                    {
                        existingValue.Value = dataDto.Value;
                        await _unitOfWork.Repository<DataModelValue>().Update(existingValue);
                    }
                    else
                    {
                        throw new SystemException($"no such row column combination found for row - {dataDto.RowId} and column - {dataDto.ColumnId}");
                    }
                }
                var amendment = new Amendment();
                var existingAmendment = await _unitOfWork.DataModelRepo.GetExistingAmendment(requestDto.DatapointId, null);
                if (existingAmendment != null)
                {
                    existingAmendment.Value = requestDto.Amendment;
                    await _unitOfWork.Repository<Amendment>().Update(existingAmendment);
                }
                else
                {
                    amendment.DatapointId = requestDto.DatapointId;
                    amendment.FilterCombinationId = null;
                    amendment.Value = requestDto.Amendment;
                    await _unitOfWork.Repository<Amendment>().Add(amendment);
                }
            }
            await _unitOfWork.SaveAsync();
        }
    


        //public async Task SaveDatapointDataInModel(DataPointValueSavingRequestDto requestdto)
        //{
        //    if (requestdto == null)
        //        throw new ArgumentNullException(nameof(requestdto), "Invalid JSON data");

        //    if (long.IsNegative(requestdto.ModelId))
        //        throw new ArgumentException("Model name cannot be empty");
        //    var utcNow = DateTime.UtcNow;

        //    var ModelFilterCombinations = await _unitOfWork.DataModelRepo.GetModelFilterCombinationsByModelIdandDatapointId(requestdto.ModelId, requestdto.DatapointId);
        //    if (ModelFilterCombinations == null || !ModelFilterCombinations.Any())
        //    {
        //        await SaveDatamodelData(requestdto);
        //        await _unitOfWork.SaveAsync();
        //        return;
        //    }
        //    foreach (var combination in ModelFilterCombinations)
        //    {
        //        var isMatch = combination.ModelFilterCombinationalValues.All(combinationValue =>
        //            requestdto.FilterDtos.Any(inputFilter =>
        //               // inputFilter.TypeId == combinationValue.DataModelFilters.FilterId &&
        //                inputFilter.ValueId == combinationValue.DimensionsId));

        //        if (isMatch)
        //        {
        //            var ModelFilterCombinationId = combination.Id;

        //            var existingDatapointData = await _unitOfWork.DataModelRepo.GetDataModelValuesByCombinationId(ModelFilterCombinationId);
        //            var updatedValues = new List<DataModelValue>();

        //            foreach (var value in existingDatapointData)
        //            {
        //                var matchingFilter = requestdto.DataDtos.FirstOrDefault(filter =>
        //                    filter.RowId == value.RowId && filter.ColumnId == value.ColumnId);

        //                if (matchingFilter != null)
        //                {
        //                    value.Value = matchingFilter.Value;
        //                    value.LastModifiedBy = requestdto.UserId;
        //                    value.LastModifiedDate = utcNow;
        //                    updatedValues.Add(value);
        //                }
        //            }

        //            if (updatedValues.Any())
        //            {
        //                await _unitOfWork.Repository<DataModelValue>().UpdateRange(updatedValues);
        //            }
        //        }
        //        else
        //        {
        //            await SaveDatamodelData(requestdto);
        //        }
        //    }
        //    await _unitOfWork.SaveAsync();
        //}

        //private async Task SaveDatamodelData(DataPointValueSavingRequestDto requestdto)
        //{
        //    var utcNow = DateTime.UtcNow;
        //    var ModelFilterCombination = new ModelFilterCombination();
        //    var modelFilterCombinationalValues = new List<SampleModelFilterCombinationValue>();
        //    var dataModelValues = new List<DataModelValue>();
        //    if (requestdto.ModelId != 0)
        //    {
        //        var datapointviewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(requestdto.DatapointId);
        //        if (datapointviewtype == null)
        //            throw new ArgumentException("datapoint view type is NULL");
        //        if (datapointviewtype != null && datapointviewtype == false)
        //        {
        //            var modelConfiguration = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(requestdto.ModelId, ModelViewTypeEnum.Fact);
        //            var modelFilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(modelConfiguration);

        //            ModelFilterCombination = new ModelFilterCombination
        //            {
        //                DataModelId = requestdto.ModelId,
        //                CreatedBy = requestdto.UserId,
        //                CreatedDate = utcNow,
        //                LastModifiedBy = requestdto.UserId,
        //                LastModifiedDate = utcNow,
        //                State = StateEnum.active
        //            };
        //            await _unitOfWork.Repository<ModelFilterCombination>().AddAsync(ModelFilterCombination);
        //            await _unitOfWork.SaveAsync();
        //            foreach (var reqfilter in requestdto.FilterDtos)
        //            {
        //                var matchingFilter = modelFilters.FirstOrDefault(filter => filter.FilterId == reqfilter.TypeId);
        //                if (matchingFilter != null)
        //                {
        //                    modelFilterCombinationalValues.Add(new SampleModelFilterCombinationValue
        //                    {
        //                        ModelFilterCombinationsId = ModelFilterCombination.Id,
        //                        DataModelFiltersId = matchingFilter.Id,
        //                        DimensionsId = reqfilter.ValueId,
        //                        CreatedBy = requestdto.UserId,
        //                        CreatedDate = utcNow,
        //                        LastModifiedBy = requestdto.UserId,
        //                        LastModifiedDate = utcNow,
        //                        State = StateEnum.active
        //                    });
        //                }
        //            }
        //            foreach (var values in requestdto.DataDtos)
        //            {
        //                dataModelValues.Add(new DataModelValue
        //                {
        //                    RowId = values.RowId,
        //                    ColumnId = values.ColumnId,
        //                    CombinationId = ModelFilterCombination.Id,
        //                    Value = values.Value,
        //                    CreatedBy = requestdto.UserId,
        //                    CreatedDate = utcNow,
        //                    LastModifiedBy = requestdto.UserId,
        //                    LastModifiedDate = utcNow,
        //                    State = StateEnum.active
        //                });
        //            }
        //        }
        //        else if (datapointviewtype != null && datapointviewtype == true)
        //        {
        //            var modelConfiguration = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelIdAndViewType(requestdto.ModelId, ModelViewTypeEnum.Narrative);
        //            var modelFilters = await _unitOfWork.DataModelRepo.GetModelFiltersByConfigId(modelConfiguration);
        //            ModelFilterCombination = new ModelFilterCombination
        //            {
        //                DataModelId = requestdto.ModelId,
        //                CreatedBy = requestdto.UserId,
        //                CreatedDate = utcNow,
        //                LastModifiedBy = requestdto.UserId,
        //                LastModifiedDate = utcNow,
        //                State = StateEnum.active
        //            };
        //            await _unitOfWork.Repository<ModelFilterCombination>().AddAsync(ModelFilterCombination);
        //            await _unitOfWork.SaveAsync();
        //            foreach (var reqfilter in requestdto.FilterDtos)
        //            {
        //                var matchingFilter = modelFilters.FirstOrDefault(filter => filter.FilterId == reqfilter.TypeId);
        //                if (matchingFilter != null)
        //                {
        //                    modelFilterCombinationalValues.Add(new SampleModelFilterCombinationValue
        //                    {
        //                        ModelFilterCombinationsId = ModelFilterCombination.Id,
        //                        DataModelFiltersId = matchingFilter.Id,
        //                        DimensionsId = reqfilter.ValueId,
        //                        CreatedBy = requestdto.UserId,
        //                        CreatedDate = utcNow,
        //                        LastModifiedBy = requestdto.UserId,
        //                        LastModifiedDate = utcNow,
        //                        State = StateEnum.active
        //                    });
        //                }
        //            }
        //            foreach (var values in requestdto.DataDtos)
        //            {
        //                dataModelValues.Add(new DataModelValue
        //                {
        //                    RowId = values.RowId,
        //                    ColumnId = null,
        //                    CombinationId = ModelFilterCombination.Id,
        //                    Value = values.Value,
        //                    CreatedBy = requestdto.UserId,
        //                    CreatedDate = utcNow,
        //                    LastModifiedBy = requestdto.UserId,
        //                    LastModifiedDate = utcNow,
        //                    State = StateEnum.active
        //                });
        //            }
        //        }
        //    }
        //    await _unitOfWork.Repository<SampleModelFilterCombinationValue>().AddRange(modelFilterCombinationalValues);
        //    await _unitOfWork.Repository<DataModelValue>().AddRange(dataModelValues);
        //}
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
                metric.MetricCode = "Narrative";
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
            long ModelFilterCombinationId = 0;
            bool isMatch = false;
            var modelId = await _unitOfWork.DataModelRepo.GetDataModelIdByDatapointIdAndOrgId(datapointSavedValuesRequestDto.DatapointId, datapointSavedValuesRequestDto.OrganizatonId);
            if (modelId == null)
                //throw new ArgumentNullException("There is no model linked to datapoint");
                return response;
            var ModelFilterCombinations = await _unitOfWork.DataModelRepo.GetModelFilterCombinationsByModelIdandDatapointId(modelId.Id, datapointSavedValuesRequestDto.DatapointId);
            //if (ModelFilterCombinations == null || !ModelFilterCombinations.Any())
                //throw new ArgumentNullException("there are no combinations present for that datapoinr");
                //return response;
            if (datapointSavedValuesRequestDto.SavedDataPointFilters == null || !datapointSavedValuesRequestDto.SavedDataPointFilters.Any())
                //throw new ArgumentException("No filters provided in the request.");
                return response;
            foreach (var combination in ModelFilterCombinations)
            {
                isMatch = combination.SampleModelFilterCombinationValues.All(combinationValue =>
                datapointSavedValuesRequestDto.SavedDataPointFilters.Any(inputFilter =>
                inputFilter.TypeId == combinationValue.DataModelFilters.FilterId &&  
                inputFilter.ValueId == combinationValue.DimensionsId));
                if (isMatch)
                {
                    ModelFilterCombinationId = combination.Id;
                    break;
                }
                
            }
            
            var amendment = await _unitOfWork.DataModelRepo.GetExistingAmendment(datapointSavedValuesRequestDto.DatapointId, ModelFilterCombinationId);
            response.Amendment = amendment?.Value;
            var datamodelValues = await _unitOfWork.DataModelRepo.GetDataModelValuesByDatapointIdCombinatinalIdAndModelId(ModelFilterCombinationId, datapointSavedValuesRequestDto.DatapointId, modelId.Id);
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


        public async Task<GetDataModelValuesForAssigningUsersResponseDto> GetDataModelValuesForAssigningUsers(long ModelId, long organizationId)
        {
            var responsedto = new GetDataModelValuesForAssigningUsersResponseDto();
            var dimensionTypes = await _unitOfWork.DataModelRepo.GetModelDimensionTypesByModelDimTypeId(ModelId, organizationId);
            var dimensionValues = await _unitOfWork.DataModelRepo.GetModelDimensionValuesByModelDimTypeId(
                dimensionTypes.Select(a => (long?)a.Id).ToList());
            var dataModelValues = await _unitOfWork.DataModelRepo.GetDataModelValuesByModelIdOrgId(ModelId, organizationId);
            var modelDimenstionTypesWithValues = new List<DataModelDimenstionTypesWithValues>();
            var modelDatamodelValues = new List<DataModelValuesForAssigning>();
            foreach (var dimtype in dimensionTypes)
            {
                var valueIds = dimensionValues
                    .Where(dv => dv.TypeId == dimtype.Id)
                    .Select(dv => new DataModelDimenstionValues
                    {
                        DimensionValueId = dv.Id,
                        DimensionValueName = dv.Name 
                    })
                    .ToList();
                var modeldimtype = new DataModelDimenstionTypesWithValues
                {
                    TypeId = dimtype.Id,
                    TypeName = dimtype.Name,
                    ValueIds = valueIds, 
                };
                modelDimenstionTypesWithValues.Add(modeldimtype);
            }
            responsedto.DataModelDimenstionTypesWithValues = modelDimenstionTypesWithValues;
            foreach (var datamodelvalue in dataModelValues)
            {
                var rowdimdto = dimensionValues
                    .Where(a => a.Id == datamodelvalue.RowId)
                    .Select(a => (a.Id, a.Name))
                    .FirstOrDefault();
                var coldimdto = dimensionValues
                    .Where(a => a.Id == datamodelvalue.ColumnId)
                    .Select(a => (a.Id, a.Name))
                    .FirstOrDefault();

                var filterDimensionDtos = datamodelvalue.Combination.SampleModelFilterCombinationValues
                    .Where(filterId => dimensionValues.Any(a => a.Id == filterId.DimensionsId))
                    .Select(filterId => dimensionValues.FirstOrDefault(a => a.Id == filterId.DimensionsId))
                    .Select(filter => new ModelDimensionHeadersDto
                    {
                        Id = filter.Id,
                        Name = filter.Name
                    })
                    .ToList();


                var modelvalue = new DataModelValuesForAssigning
                {
                    DataModelValueId = datamodelvalue.Id,
                    DatapointId = datamodelvalue.DataPointValuesId,
                    DatapointName = datamodelvalue.DataPointValues.Name,
                    DatapointCode = datamodelvalue.DataPointValues.Code,
                    
                    RowModelDimensionDto = rowdimdto.Id != 0 || rowdimdto.Id != null ? new ModelDimensionHeadersDto
                    {
                        Id = rowdimdto.Id,
                        Name = rowdimdto.Name
                    } : null,
                    ColumnModelDimensionDto = coldimdto.Id != 0 || coldimdto.Id != null ? new ModelDimensionHeadersDto
                    {
                        Id = coldimdto.Id,
                        Name = coldimdto.Name
                    } : null,
                    FiltersDimensionDto = filterDimensionDtos,
                    IsBlocked = datamodelvalue.IsBlocked,
                    Accountable = datamodelvalue.AccountableUserId,
                    Responsible = datamodelvalue.ResponsibleUserId
                };

                modelDatamodelValues.Add(modelvalue);
            }
            responsedto.DataModelValuesForAssigning = modelDatamodelValues;

            return responsedto;

        }
    }
}
