using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Dto.Topics;
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
        Task<IEnumerable<TopicsResponseDto>> GetMethod(int tableType, long? Id);
    }
}
