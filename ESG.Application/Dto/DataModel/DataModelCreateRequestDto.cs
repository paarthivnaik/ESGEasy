using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelCreateRequestDto
    {
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public string? ModelName { get; set; }
        public List<long> Datapoints { get; set; } = new List<long>();
        public List<DimensionTypeDTO> DimensionTypes { get; set; } = new List<DimensionTypeDTO>();

        public class DimensionTypeDTO
        {
            public long DimensionTypeId { get; set; }
            public List<long> DimensionValues { get; set; } = new List<long>();
        }
    }

}
