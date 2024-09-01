using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelCreateRequestDto
    {
        public long DataPointId { get; set; }
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public List<DimensionTypeDataDTO> DimensionTypes { get; set; } = new List<DimensionTypeDataDTO>();

        public class DimensionTypeDataDTO
        {
            public long DimensionTypeId { get; set; }
            public List<DimensionValueDTO> DimensionValues { get; set; } = new List<DimensionValueDTO>();
        }

        public class DimensionValueDTO
        {
            public long DimensionValueId { get; set; }
        }
    }
}
