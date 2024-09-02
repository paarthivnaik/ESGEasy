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
                throw new ArgumentNullException(nameof(dataModelCreateRequestDto), "Invalid JSON data");

            if (string.IsNullOrWhiteSpace(dataModelCreateRequestDto.ModelName))
                throw new ArgumentException("Model name cannot be empty");

            if (dataModelCreateRequestDto.UserId <= 0)
                throw new ArgumentException("Invalid user ID");

            var utcNow = DateTime.UtcNow;

            var dataModel = new ESG.Domain.Entities.DataModel
            {
                ModelName = dataModelCreateRequestDto.ModelName,
                CreatedBy = dataModelCreateRequestDto.UserId,
                CreatedDate = utcNow,
                LastModifiedBy = dataModelCreateRequestDto.UserId,
                LastModifiedDate = utcNow,
                State = StateEnum.active
            };

            await _unitOfWork.Repository<ESG.Domain.Entities.DataModel>().AddAsync(dataModel);
            await _unitOfWork.SaveAsync();

            var dataModelId = dataModel.Id;
            var modelDatapoints = new List<ModelDatapoints>();
            var modelDimensionTypes = new List<ModelDimensionTypes>();
            var modelDimensionValues = new List<ModelDimensionValues>();

            // Processing datapoints directly as list of longs
            foreach (var datapointId in dataModelCreateRequestDto.Datapoints)
            {
                modelDatapoints.Add(new ModelDatapoints
                {
                    DataModelId = dataModelId,
                    DatapointValuesId = datapointId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.UserId,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.UserId,
                    LastModifiedDate = utcNow
                });
            }

            // Processing dimension types and dimension values
            foreach (var dimensionType in dataModelCreateRequestDto.DimensionTypes)
            {
                modelDimensionTypes.Add(new ModelDimensionTypes
                {
                    DataModelId = dataModelId,
                    DimensionTypeId = dimensionType.DimensionTypeId,
                    State = StateEnum.active,
                    CreatedBy = dataModelCreateRequestDto.UserId,
                    CreatedDate = utcNow,
                    LastModifiedBy = dataModelCreateRequestDto.UserId,
                    LastModifiedDate = utcNow
                });

                foreach (var dimensionValueId in dimensionType.DimensionValues)
                {
                    modelDimensionValues.Add(new ModelDimensionValues
                    {
                        DataModelId = dataModelId,
                        DimensionsId = dimensionValueId,
                        State = StateEnum.active,
                        CreatedBy = dataModelCreateRequestDto.UserId,
                        CreatedDate = utcNow,
                        LastModifiedBy = dataModelCreateRequestDto.UserId,
                        LastModifiedDate = utcNow
                    });
                }
            }

            // Adding all to the database
            await _unitOfWork.Repository<ModelDatapoints>().AddRange(modelDatapoints);
            await _unitOfWork.Repository<ModelDimensionTypes>().AddRange(modelDimensionTypes);
            await _unitOfWork.Repository<ModelDimensionValues>().AddRange(modelDimensionValues);
            await _unitOfWork.SaveAsync();
        }



    }
}
