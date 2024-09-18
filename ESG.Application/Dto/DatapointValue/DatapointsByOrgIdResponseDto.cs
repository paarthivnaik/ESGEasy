using ESG.Domain.Entities.Hierarchies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DatapointValue
{
    public class DatapointsByOrgIdResponseDto
    {
        public List<TopicDto> TopicDto { get; set; } = new List<TopicDto>(); 
    }

    public class TopicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<StandardDto> StandardDto { get; set; } = new List<StandardDto>();
    }

    public class StandardDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DisclosureRequirementDto> DisclosureRequirement { get; set; } = new List<DisclosureRequirementDto>();
    }

    public class DisclosureRequirementDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DatapointDto> DatapointDto { get; set; } = new List<DatapointDto>(); 
    }

    public class DatapointDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsNarrative { get; set; }
    }

}
