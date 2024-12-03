using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IHierarchyService
    {
        Task AddHierarchy(HierarchyCreateRequestDto request);
        Task<bool> CheckDataModelValueOfDatapoint(CheckDataModelValueOfDatapointRegDto requsetdto);
        Task<IEnumerable<HeirarchyDataResponseDto>> GetMethod(int tableType, long? Id, long? organizationId, long? languageId);
        Task<HierarchyResponseDto> GetHierarchyByOrganizationId(long organizationId, long? languageId);
        Task<List<GetDatapointsAssignedToUserResponseDto>> GetDatapointsAssignedToUser(long organizationId, long userId);
        Task<List<DatapointsForDataModelResponseDto>> GetDatapointsForDataModel(long organizationId, long? modelId, long? languageId);
        //Task<HierarchyResponseDto> GetUserDatapoints(long UserId, long organizationId);
    }
}
