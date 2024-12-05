using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Hierarchy
{
    public interface IHierarchyRepo
    {
        Task<long> GetNextHierarchyIdAsync();
        Task<IEnumerable<Domain.Models.Hierarchy>> GetHierarchies(long hierarchyId);
        Task<List<long>> GetDatapointsByHierarchyId(long? hierarchyId);
        Task<List<long>> GetDatapointsLinkedToModelByOrganizationId(long? organizationId);
        Task<IEnumerable<Topic>> GetTopics();
        Task<IEnumerable<Standard>> GetStandards(long? topicId);
        Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirements(long? standardId);
        Task<IEnumerable<DataPointValue>> GetDatapoints(long? disReqId, long? organizationId);
        Task<long> GetHierarchyIdByOrgId(long organizationId);
        Task<IEnumerable<Domain.Models.Hierarchy>> GetHierarchyById(long? hierarchyId);
        Task<long> GetHierarchyIdByUserIdOrgId(long UserId, long orgId);
        Task<IEnumerable<long>> GetRemainingDatapointsByOrganizationId(long organizationId);
        Task<List<DataModelValue>> GenerateDataModelValues(List<long>? datapoints, long organizationId, long userId);
    }
}
