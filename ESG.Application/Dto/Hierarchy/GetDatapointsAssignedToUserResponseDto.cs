using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class GetDatapointsAssignedToUserResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? UOMCode { get; set; }
        
    }
}
