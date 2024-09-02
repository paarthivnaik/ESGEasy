using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class HierarchyCreateRequestDto
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public List<long> DatapointIds { get; set; } = new List<long>();
    }


}
