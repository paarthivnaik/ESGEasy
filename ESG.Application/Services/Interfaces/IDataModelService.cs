using ESG.Application.Dto.DataModel;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDataModelService
    {
        Task CreateDataModel(DataModelCreateRequestDto requestdto);
        Task ConfiguringModel(ConfiguringDataModelRequestDto configuringDataModelRequestDto);
        Task<List<long>> GetDimensionTypeByModelId(long modelId);
        Task<List<long>> GetDimensionValuesByTypeId(long dimensionTypeId);
    }
}
