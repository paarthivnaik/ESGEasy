using ESG.Application.Common.Interface.DataModel;
using ESG.Application.Dto.DataModel;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataModel
{
    public class DataModelRepo : GenericRepository<DataPointValues>, IDataModelRepo
    {
        private readonly ApplicationDbContext _context;
        public DataModelRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        //public async Task CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        //{
        //    if (dataModelCreateRequestDto == null)
        //        throw new ArgumentException("Invalid JSON data");

        //    // Create DataModels
        //    var dataModels = new List<ESG.Domain.Entities.DataModel>();
        //    var modelDatapoint = new ModelDatapoints();
        //    var modelDimensionTypes = new ModelDimensionTypes();
        //    var modelDimensionValues = new ModelDimensionValues();

        //    foreach (var dimensionTypeDto in dataModelCreateRequestDto.DimensionTypes)
        //    {
        //        var dataModel = new ESG.Domain.Entities.DataModel
        //        {
        //            OrganizationId = dataModelCreateRequestDto.OrganizationId,
        //            CreatedBy = dataModelCreateRequestDto.UserId,
        //            CreatedDate = DateTime.UtcNow,
        //            LastModifiedBy = dataModelCreateRequestDto.UserId,
        //            LastModifiedDate = DateTime.UtcNow,
        //            State = StateEnum.active
        //        };
        //        foreach (var dimensionType in dataModelCreateRequestDto.DimensionTypes)
        //        {
        //            modelDimensionTypes.DataModelId = dataModel.Id;
        //            modelDimensionTypes.DimensionTypeId = dimensionTypeDto.DimensionTypeId;
        //            dataModel.ModelDimensionTypes = new List<ModelDimensionTypes> { modelDimensionTypes };
        //            foreach (var dimvalues in dimensionType.DimensionValues)
        //            {
        //                modelDimensionValues.DataModelId = dataModel.Id;
        //                modelDimensionValues.DimensionsId = dimvalues.DimensionValueId;
        //                dataModel.ModelDimensionValues = new List<ModelDimensionValues> { modelDimensionValues };
        //            }
        //        }
        //        dataModels.Add(dataModel);
        //    }

        //    // Add DataModels to the context
        //    _context.DataModels.AddRange(dataModels);
        //    await _context.SaveChangesAsync();

            //// Insert DataModels
            //var dataModels = new ESG.Domain.Entities.DataModel();

            //dataModels = new ESG.Domain.Entities.DataModel
            //{
            //    OrganizationId = dataModelCreateRequestDto.OrganizationId,
            //    CreatedBy = dataModelCreateRequestDto.UserId,
            //};
            //foreach (var dimansionType in dataModelCreateRequestDto.DimensionTypes)
            //{
            //    modelDimensionTypes.DataModelId = dataModels.Id;
            //    modelDimensionTypes.DimensionTypeId = dimansionType.DimensionTypeId;
            //    foreach (var dimvalue in dimansionType.DimensionValues)
            //    {
            //        modelDimensionValues.DataModelId = dataModels.Id;
            //        modelDimensionValues.DimensionsId = dimvalue.DimensionValueId;
            //    }
            //    dataModels.Add(dataModels);
            ////}

            //_context.DataModels.AddRange(dataModels);
            //await _context.SaveChangesAsync();

            
        
    }
}
