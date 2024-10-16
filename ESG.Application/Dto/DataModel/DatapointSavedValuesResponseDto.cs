using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DatapointSavedValuesResponseDto
    {
        public long DatapointId { get; set; }
        public string Name { get; set; }
        public string? UOMCode { get; set; }
        public bool? IsNarrative { get; set; }
        public string? Amendment { get; set; }
        public List<DatapointSavedValues> DatapointSavedValues { get; set; }
    }

    public class DatapointSavedValues
    {
        public long DataModelValueId { get; set; }
        public long RowId { get; set; }
        public long? ColumnId { get; set; }
        public string? Value { get; set; }
    }

}
