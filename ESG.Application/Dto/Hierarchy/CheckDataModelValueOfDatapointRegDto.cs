using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class CheckDataModelValueOfDatapointRegDto
    {
        public List<long> DatapointIds { get; set; }
        public long OrganizationId { get; set; }
    }
}
