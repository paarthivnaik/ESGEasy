using ESG.Application.Dto.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.DataModel
{
    public interface IDataModelRepo
    {
        //Task CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto);
        Task<List<long>?> GetDimensionTypesByModelId(long modelId);
        Task<List<long>?> GetDimensionValuesByModelId(long modelId);
    }
}
