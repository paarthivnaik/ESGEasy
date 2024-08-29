using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Hierarchy
{
    public interface IHierarchyRepo
    {
        //Task AddHierarchy(HierarchyCreateRequestDto request);
        Task AddHierarchyRecursive(HierarchyCreateRequestDto request, long? parentId);
        Task<IEnumerable<Topic>> GetTopics();
        Task<IEnumerable<Standard>> GetStandards(long? topicId);
        Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirements(long? standardId);
        Task<IEnumerable<DataPointValues>> GetDatapoints(long? disReqId);
    }
}
