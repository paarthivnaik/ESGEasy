using ESG.Application.Dto.Hierarchy;
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
    }
}
