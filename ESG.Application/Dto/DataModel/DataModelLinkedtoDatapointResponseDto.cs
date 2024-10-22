using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelLinkedtoDatapointResponseDto
    {
        public long ModelId { get; set; }
        public string? Name { get; set; }
        public DatapointDimensionType? RowDimensionType { get; set; }
        public DatapointDimensionType? ColumnDimensionType { get; set; }
        public List<DatapointDimensionType>? FilterDimensionTypes { get; set; }
    }
    public class DatapointDimensionType
    {
        public long DimensionTypeId { get; set; }
        public string? DimensionTypeName { get; set; }
        public List<DatapointDimensionValue>? DimensionValues { get; set; }
    }

    public class DatapointDimensionValue
    {
        public long DimensionValueId { get; set; }
        public string? DimensionValueName { get; set; }
    }
}
