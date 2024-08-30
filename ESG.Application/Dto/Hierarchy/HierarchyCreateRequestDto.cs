using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class HierarchyCreateRequestDto
    {
        public List<HierarchyEntryDto> Entries { get; set; }
    }

    public class HierarchyEntryDto
    {
        public long DataPointValuesId { get; set; }
    }

}
