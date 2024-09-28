using ESG.Application.Dto.DataModel;

using ESG.Domain.Enum;
using ESG.Domain.Models;
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
        Task<List<Domain.Models.DataModel>> GetDataModelsIncludingDefaultByOrgId(long OrgId);
        Task<Domain.Models.DataModel?> GetDataModelIdByDatapointIdAndOrgId(long datapointId, long orgId);
        Task<(long Id, string Name)> GetRowDimensionTypeIdAndNameFromConfigurationByModelId(long modelId, ModelViewTypeEnum viewTypeEnum);
        Task<(long Id, string Name)> GetColumnDimensionTypeIdAndNameByDimensionTypeId(long typeId);
        Task<IEnumerable<(long Id, string Name)>> GetFilterDimensionTypeByConfigurationId(long configurationId);
        Task<long?> GetColumnIdInModelCnfigurationByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum);
        Task<IEnumerable<(long Id, string Name)>> GetDimensionValuesByTypeId(long? modelDimensionTypeId);
        Task<long> GetModelconfigurationIdByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum);
        Task<long?> GetModelDimensionTypeIdByDimensiionTypeID(long modelId,long dimensionTypeId);
        Task<List<ModelConfiguration>> GetConfigurationViewTypesForDataModel(long datamodelId);
        Task<bool?> GetDatapointViewType(long datapointId);
        Task<IEnumerable<DataModelFilter>> GetModelFiltersByConfigId(long configId);
        Task<DataPointValue> GetDatapointMetric(long datapointId, long organizationId);
        Task<IEnumerable<ModelFilterCombination>> GetModelFilterCombinationsByModelIdandDatapointId(long modelId, long datapointId);
        Task<IEnumerable<DataModelValue>> GetDataModelValuesByCombinationId(long combinationId);

        Task<List<ModelDimensionType>?> GetDimensionTypesByModelIdAndOrgId(long modelId, long orgId);
        //Task<List<DimensionType>?> GetDimensionTypesByModelId(long modelId);

    }
}
