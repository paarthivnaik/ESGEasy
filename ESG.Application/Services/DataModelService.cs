using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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
            var modelConfiguration = new Domain.Entities.ModelConfiguration
            {
                DataModelId = configuringDataModelRequestDto.DataModelId,
                ViewType = configuringDataModelRequestDto.ViewType,
                RowId = configuringDataModelRequestDto.RowId,
                ColumnId = configuringDataModelRequestDto.ColumnId,
                State = StateEnum.active,
                CreatedBy = configuringDataModelRequestDto.UserId,
            };
            await _unitOfWork.Repository<Domain.Entities.ModelConfiguration>().AddAsync(modelConfiguration);
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

            var dataModel = new ESG.Domain.Entities.DataModel
            {
                OrganizationId = dataModelCreateRequestDto.OrganizationId,
                ModelName = dataModelCreateRequestDto.ModelName,
                CreatedBy = dataModelCreateRequestDto.CreatedBy,
                CreatedDate = utcNow,
                LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                LastModifiedDate = utcNow,
                State = StateEnum.active
            };
            await _unitOfWork.Repository<ESG.Domain.Entities.DataModel>().AddAsync(dataModel);
            await _unitOfWork.SaveAsync();

            var dataModelId = dataModel.Id;
            var modelDatapoints = new List<ModelDatapoints>();
            var modelDimensionTypes = new ModelDimensionTypes();
            var modelDimensionValues = new List<ModelDimensionValues>();
            var modelConfigurations = new ESG.Domain.Entities.ModelConfiguration();
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
                await _unitOfWork.Repository<ESG.Domain.Entities.ModelDimensionTypes>().AddAsync(modelDimensionTypes);
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
            if (dataModelCreateRequestDto.Fact != null)
            {
                modelConfigurations = new Domain.Entities.ModelConfiguration
                {
                    DataModelId = dataModelId,
                    RowId = dataModelCreateRequestDto.Fact.RowId,
                    ColumnId = dataModelCreateRequestDto.Fact.ColumnId,
                    ViewType = ModelViewTypeEnum.Fact,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<ESG.Domain.Entities.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
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
            if (dataModelCreateRequestDto.Narrative != null)
            {
                modelConfigurations = new Domain.Entities.ModelConfiguration
                {
                    DataModelId = dataModelId,
                    RowId = dataModelCreateRequestDto.Narrative.RowId,
                    ColumnId = null,
                    ViewType = ModelViewTypeEnum.Narrative,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.CreatedBy,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.CreatedBy,
                    LastModifiedDate = utcNow
                };
                await _unitOfWork.Repository<ESG.Domain.Entities.ModelConfiguration>().AddAsync(modelConfigurations);
                await _unitOfWork.SaveAsync();
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
            await _unitOfWork.Repository<ModelDatapoints>().AddRange(modelDatapoints);
            await _unitOfWork.Repository<ModelDimensionValues>().AddRange(modelDimensionValues);
            await _unitOfWork.Repository<DataModelFilters>().AddRange(modelFilters);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DataModelsResponseDto>> GetDataModelsResponsesByOrgId(long organizationId)
        {
            var responseobj = new List<DataModelsResponseDto>();
            var datamodels = await _unitOfWork.DataModelRepo.GetDataModelsByOrgId(organizationId);
            if (datamodels != null)
            {
                foreach (var datamodel in datamodels)
                {
                    var response = new DataModelsResponseDto
                    {
                        Id = datamodel.Id,
                        Name = datamodel.ModelName,
                        RowDimension = await GetRowDimensionDto(datamodel.Id),
                        ColumnDimension = await GetColumnDimensionDto(datamodel.Id),
                        FilterDimension = await GetFilterDimensions(datamodel.Id)
                    };
                    responseobj.Add(response);
                }
            }
            return responseobj;
        }

        private async Task<DimensionTypeDto> GetRowDimensionDto(long modelId)
        {
            var filterdimresponsedto = new List<DimensionTypeDto>();
            var dimensionType = await _unitOfWork.DataModelRepo.GetRowDimensionTypeIdAndNameFromConfigurationByModelId(modelId);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(dimensionType.Id);
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
        private async Task<DimensionTypeDto?> GetColumnDimensionDto(long modelId)
        {
            DimensionTypeDto? dimTypeDto = null;
            var columnId = await _unitOfWork.DataModelRepo.GetColumnIdInModelCnfigurationByModelId(modelId);
            if (columnId == null)
                return null;

            var dimensionType = await _unitOfWork.DataModelRepo.GetColumnDimensionTypeIdAndNameByDimensionTypeId(columnId!.Value);
            var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(dimensionType.Id);
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


        private async Task<List<DimensionTypeDto>?> GetFilterDimensions(long modelId)
        {
            var responsedto = new List<DimensionTypeDto>();
            var configurationId = await _unitOfWork.DataModelRepo.GetModelconfigurationIdByModelId(modelId);
            if (configurationId >= 0 || configurationId != null)
            {
                var filterDimensions = await _unitOfWork.DataModelRepo.GetFilterDimensionTypeByConfigurationId(configurationId);
                foreach (var filterdim in filterDimensions)
                {
                    var modelDimensionTypeId = await _unitOfWork.DataModelRepo.GetModelDimensionTypeIdByDimensiionTypeID(filterdim.Id);
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
    }
}
