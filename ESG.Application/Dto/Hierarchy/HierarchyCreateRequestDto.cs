using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class HierarchyCreateRequestDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDataPoint { get; set; }
        public IEnumerable<HierarchyCreateRequestDto> Children { get; set; } = new List<HierarchyCreateRequestDto>();
    }
}
