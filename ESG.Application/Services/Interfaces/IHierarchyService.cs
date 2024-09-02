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
        Task<IEnumerable<HeirarchyDataResponseDto>> GetMethod(int tableType, long? Id);
        Task<IEnumerable<HierarchyResponseDto>> GetHierarchydata(long organizationId);
    }
}
