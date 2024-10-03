using ESG.Application.Dto.DataModel;
using ESG.Domain.Enum;
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
        Task SaveDatapointDataInModel(DataPointValueSavingRequestDto requestdto);
        Task<IEnumerable<DataModelsResponseDto>> GetDataModelsResponsesByOrgId(long OrganizationId);
        Task<DataModelLinkedtoDatapointResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long organizationId);
        Task<DatapointMetricResponseDto> GetDatapointMetric(long datapointId, long organizationId);
        Task ConfiguringModel(ConfiguringDataModelRequestDto configuringDataModelRequestDto);
        Task<DatapointSavedValuesResponseDto> GetDatapointSavedValues(DatapointSavedValuesRequestDto datapointSavedValuesRequestDto); 
        Task<GetDataModelValuesForAssigningUsersResponseDto> GetDataModelValuesForAssigningUsers(long ModelId, long organizationId); 





        //Task<List<long>> GetDimensionTypeByModelId(long modelId);
        //Task<List<long>> GetDimensionValuesByTypeId(long dimensionTypeId);
    }
}
