using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class DatapointsForDataModelResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<HierarchyStandard> Children { get; set; }
    }
    public class HierarchyStandard
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<HierarchyDisclosureRequirement> Children { get; set; }
    }
    public class HierarchyDisclosureRequirement
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<HierarchyDatapoint> children { get; set; }
    }
    public class HierarchyDatapoint
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsNarrative{ get; set; }
    }
}
