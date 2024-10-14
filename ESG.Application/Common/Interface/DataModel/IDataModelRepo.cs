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
        Task<List<(long Id, string? Name)>?> GetFilterDimensionTypeByConfigurationId(long configurationId);
        Task<long?> GetColumnIdInModelCnfigurationByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum);
        Task<IEnumerable<(long Id, string Name)>> GetDimensionValuesByTypeId(long? modelDimensionTypeId);
        Task<long> GetModelconfigurationIdByModelIdAndViewType(long modelId, ModelViewTypeEnum viewTypeEnum);
        Task<long?> GetModelDimensionTypeIdByDimensiionTypeID(long modelId,long dimensionTypeId);
        Task<List<ModelConfiguration>> GetConfigurationViewTypesForDataModel(long datamodelId);
        Task<bool?> GetDatapointViewType(long datapointId);
        Task<List<long>> GetDatapointsByViewType(List<long> datapointIds);
        Task<IEnumerable<DataModelFilter>> GetModelFiltersByConfigId(long configId);
        Task<DataPointValue> GetDatapointMetric(long datapointId, long organizationId);
        Task<IEnumerable<ModelFilterCombination>> GetModelFilterCombinationsByModelIdandDatapointId(long modelId, long datapointId);
        Task<IEnumerable<DataModelValue>> GetDataModelValuesByDatapointIdCombinatinalIdAndModelId(long? combinationId, long datapointId, long modelId);

        Task<List<ModelDimensionType>?> GetDimensionTypesByModelIdAndOrgId(long modelId, long orgId);
        Task<List<DataModelValue>?> GetDataModelValues(long modelId, long datapointId, List<long> rowId, List<long?> columnId, long? filterCombinationId);
        Task<List<long>?> GetModelFilterCombinations(long modelId);
        Task<List<DataModelFilter>?> GetDataModelFiltersByConfigId(long configId);
        Task<List<DataModelValue>?> GetDataModelValuesByModelIdOrgId(long modelId, long organizationId);
        Task<List<SampleModelFilterCombinationValue>?> GetDataModelCombinationalValuesByModelFilterCombinationIds(List<long> combinationalIds);
        Task<IEnumerable<(long Id, long DimensionTypeId, string Name)>> GetModelDimensionTypesByModelDimTypeId(long modelId, long organizationId);
        Task<bool> VerifyIsDefaultModel(long modelId, long organizationId);
        Task<IEnumerable<(long Id, string Name, long TypeId)>> GetModelDimensionValuesByModelDimTypeId(List<long?> modelDimensionTypeIds);
        Task<Amendment?> GetExistingAmendment(long datapointId, long? combinationId);
        Task<List<DataModelValue>?> GetDataModelValuesById(List<long> ids, long modelId, long OrganizationId);
    }
}
