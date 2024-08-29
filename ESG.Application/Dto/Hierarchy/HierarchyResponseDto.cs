using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class HierarchyResponseDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<HierarchyResponseDto> Children { get; set; } = new List<HierarchyResponseDto>();
    }
}
