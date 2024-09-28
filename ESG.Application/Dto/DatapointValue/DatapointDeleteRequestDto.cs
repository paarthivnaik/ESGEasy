using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DatapointValue
{
    public class DatapointDeleteRequestDto
    {
        public long Id { get; set; }
        public StateEnum State { get; set; }
    }
}
