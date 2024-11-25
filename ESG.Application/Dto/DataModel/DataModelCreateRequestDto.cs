using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelCreateRequestDto
    {
        public long DataModelId { get; set; }
        public long OrganizationId { get; set; }
        public string ModelName { get; set; }
        public string Purpose { get; set; }
        public long CreatedBy { get; set; } 
        public bool IsDefault { get; set; }
        public List<long>? Datapoints { get; set; } 
        public List<DimensionDTO> Dimension { get; set; }
        public FactDTO? Fact { get; set; } = new FactDTO();
        public NarrativeDTO? Narrative { get; set; }

        public class DimensionDTO
        {
            public long TypeId { get; set; }
            public List<long> Values { get; set; }
        }

        public class FactDTO
        {
            public long? RowId { get; set; }
            public long? ColumnId { get; set; }
            public List<long>? Filters { get; set; }
        }

        public class NarrativeDTO
        {
            public long? RowId { get; set; }
            public List<long>? Filters { get; set; }
        }
    }

}
