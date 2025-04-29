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
        Task<IEnumerable<Domain.Models.Topic>> GetTopics();
        Task<IEnumerable<Domain.Models.Topic>> GetTopicTranslationsByLangId(long? langId, long? organizationId,long? Id);
        Task<IEnumerable<Domain.Models.Standard>> GetStandardTranslationsByLangId(long? langId, long? organizationId,long? tableType,long? Id);
        Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetDisclosureRequirementTranslations(long? languageId, long? organizationId, long? tableType, long? Id);
        Task<IEnumerable<DataPointValue>> GetDatapointTranslations(long? tableType, long? Id,long? organizationId,long? languageId);
        Task<IEnumerable<Domain.Models.Standard>> GetStandards(long? topicId);
        Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetDisclosureRequirements(long? standardId);
        Task<IEnumerable<DataPointValue>> GetDatapoints(long? disReqId, long? organizationId);
        Task<long> GetHierarchyIdByOrgId(long organizationId);
        Task<IEnumerable<Domain.Models.Hierarchy>> GetHierarchyById(long? hierarchyId);
        Task<long> GetHierarchyIdByUserIdOrgId(long UserId, long orgId);
        Task<IEnumerable<long>> GetRemainingDatapointsByOrganizationId(long organizationId);
        
    }
}
