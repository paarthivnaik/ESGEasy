using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DataModel;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DataModelService : IDataModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        {
            if (dataModelCreateRequestDto == null)
                throw new ArgumentException("Invalid JSON data");

            // Create DataModel
            var dataModel = new ESG.Domain.Entities.DataModel
            {
                ModelId = 1,
                OrganizationId = dataModelCreateRequestDto.OrganizationId,
                CreatedBy = dataModelCreateRequestDto.UserId,
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = dataModelCreateRequestDto.UserId,
                LastModifiedDate = DateTime.UtcNow,
                State = StateEnum.active
            };

            // Add DataModel to the context
            await _unitOfWork.Repository<ESG.Domain.Entities.DataModel>().AddAsync(dataModel);
            await _unitOfWork.SaveAsync();

            // Get the ID of the created DataModel
            var dataModelId = dataModel.Id;

            // Create and add ModelDatapoints
            var modelDatapoint = new ModelDatapoints
            {
                DataModelId = dataModelId,
                DatapointValuesId = dataModelCreateRequestDto.DataPointId,
                State = StateEnum.active,
                CreatedBy = dataModelCreateRequestDto.UserId,
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = dataModelCreateRequestDto.UserId,
                LastModifiedDate = DateTime.UtcNow
            };

            await _unitOfWork.Repository<ModelDatapoints>().AddAsync(modelDatapoint);
            await _unitOfWork.SaveAsync();

            // Create and add ModelDimensionTypes
            var modelDimensionTypes = new List<ModelDimensionTypes>();
            foreach (var dimensionType in dataModelCreateRequestDto.DimensionTypes)
            {
                var modelDimensionType = new ModelDimensionTypes
                {
                    DataModelId = dataModelId,
                    DimensionTypeId = dimensionType.DimensionTypeId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.UserId,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedBy = dataModelCreateRequestDto.UserId,
                    LastModifiedDate = DateTime.UtcNow
                };
                modelDimensionTypes.Add(modelDimensionType);
            }

            await _unitOfWork.Repository<ModelDimensionTypes>().AddRange(modelDimensionTypes);
            await _unitOfWork.SaveAsync();

            // Create and add ModelDimensionValues
            var modelDimensionValues = new List<ModelDimensionValues>();
            foreach (var dimensionType in dataModelCreateRequestDto.DimensionTypes)
            {
                foreach (var dimValue in dimensionType.DimensionValues)
                {
                    var modelDimensionValue = new ModelDimensionValues
                    {
                        DataModelId = dataModelId,
                        DimensionsId = dimValue.DimensionValueId,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequestDto.UserId,
                        CreatedDate = DateTime.UtcNow,
                        LastModifiedBy = dataModelCreateRequestDto.UserId,
                        LastModifiedDate = DateTime.UtcNow
                    };
                    modelDimensionValues.Add(modelDimensionValue);
                }
            }

            await _unitOfWork.Repository<ModelDimensionValues>().AddRange(modelDimensionValues);
            await _unitOfWork.SaveAsync();
        }

    }
}
