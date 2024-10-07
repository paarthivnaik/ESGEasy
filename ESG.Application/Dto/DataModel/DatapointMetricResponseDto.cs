using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DatapointMetricResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? MetricId { get; set; }
        public string? MetricCode { get; set; }
        public bool? IsNarrative { get; set; }
    }
}
