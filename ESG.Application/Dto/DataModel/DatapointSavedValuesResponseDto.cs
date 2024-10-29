using Microsoft.AspNetCore.Mvc;
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
        public long? CombinationId { get; set; }
        public long? AmendmentId { get; set; }
        public string? Amendment { get; set; }
        public List<DatapointSavedValues> DatapointSavedValues { get; set; }
    }

    public class DatapointSavedValues
    {
        public long DataModelValueId { get; set; }
        public long RowId { get; set; }
        public long? ColumnId { get; set; }
        public string? Value { get; set; }
        public bool? IsBlocked { get; set; }
        public long? ResponsibleUserId { get; set; }
        public string? FileData { get; set; }
        public string? FileName { get; set; }
    }

}
