using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Hierarchy
{
    public class HierarchyResponseDto
    {
        public List<TopicDto> Topics { get; set; }
        public List<SubTopicDto> SubTopics { get; set; }
        public List<DisclosureRequirementDto> DisclosureRequirements { get; set; }
        public List<DataPointDto> DataPoints { get; set; }
        public class TopicDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        public class SubTopicDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public long TopicId { get; set; }
        }

        public class DisclosureRequirementDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public long SubTopicId { get; set; }
        }

        public class DataPointDto
        {
            public long Id { get; set; }
            public string ShortText { get; set; }
            public string? UOMCode { get; set; }
            public long DisclosureRequirementId { get; set; }
        }
    }
}
