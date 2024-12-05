using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DatapointValue
{
    public class DatapointValueDeleteRequestDto
    {
        public long DatapointId { get; set; }
        public long OrganizationId { get; set; }
        public StateEnum State { get; set; }
    }
}
