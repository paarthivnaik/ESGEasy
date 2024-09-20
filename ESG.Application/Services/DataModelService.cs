using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using ESG.Domain.Entities.DataModels;
using ESG.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                                FilterDimension = await GetFilterDimensions(datamodel.Id, viewType.ViewType)
                            };
                        }
                        else if (viewType.ViewType == ModelViewTypeEnum.Narrative)
                        {
                            response.NarrativeView = new NarrativeViewDto
                            {
                                RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                                FilterDimension = await GetFilterDimensions(datamodel.Id, viewType.ViewType)
                            };
                        }
                    }
                    responseobj.Add(response);
                }
            }
            return responseobj;
        }
        public async Task<DataModelsResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long organizationId)
        {
            var responseobj = new DataModelsResponseDto();
            var datamodel = await _unitOfWork.DataModelRepo.GetDataModelIdByDatapointIdAndOrgId(datapointId, organizationId);
            if (datamodel != null)
            {
                var modelConfigWithViewTypes = await _unitOfWork.DataModelRepo.GetConfigurationViewTypesForDataModel(datamodel.Id);
                responseobj = new DataModelsResponseDto
                {
                    Id = datamodel.Id,
                    Name = datamodel.ModelName,
                    FactView = null,
                    NarrativeView = null
                };
                foreach (var viewType in modelConfigWithViewTypes)
                {
                    if (viewType.ViewType == ModelViewTypeEnum.Fact)
                    {
                        responseobj.FactView = new FactViewDto
                        {
                            RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                            ColumnDimension = await GetColumnDimensionDto(datamodel.Id, viewType.ViewType),
                            FilterDimension = await GetFilterDimensions(datamodel.Id, viewType.ViewType)
                        };
                    }
                    else if (viewType.ViewType == ModelViewTypeEnum.Narrative)
                    {
                        responseobj.NarrativeView = new NarrativeViewDto
                        {
                            RowDimension = await GetRowDimensionDto(datamodel.Id, viewType.ViewType),
                            FilterDimension = await GetFilterDimensions(datamodel.Id, viewType.ViewType)
                        };
                    }
                }
            }
            return responseobj;
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
            DimensionTypeDto? dimTypeDto = null;
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
        private async Task<List<DimensionTypeDto>?> GetFilterDimensions(long modelId, ModelViewTypeEnum viewTypeEnum)
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

        public async Task SaveDatapointDataInModel(DataPointValuesSavingRequestDto requestdto)
        {
            if (requestdto == null)
                throw new ArgumentNullException(nameof(requestdto), "Invalid JSON data");

            if (long.IsNegative(requestdto.ModelId))
                throw new ArgumentException("Model name cannot be empty");
            var utcNow = DateTime.UtcNow;
            var modelcombination = new ModelCombinations();
            
            var modelFilterCombinationalValues = new List<ModelFilterCombinationalValues>();
            var dataModelValues = new List<DataModelValues>();
            if (requestdto.ModelId != 0)
            {
                var datapointviewtype = await _unitOfWork.DataModelRepo.GetDatapointViewType(requestdto.DatapointId);
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
                else if(datapointviewtype != null && datapointviewtype == true)
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
            await _unitOfWork.SaveAsync();
        }
    }
}
