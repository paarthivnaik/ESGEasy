using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelValuesDto
    {
        public long? DatapointId { get; set; }
        public long? RowId { get; set; }
        public long? ColumnId { get; set; }
        public long? combinationId { get; set; }
        public bool? IsBlocked { get; set; }
        public long? Accountable {  get; set; }
        public long? Responsible { get; set; }
    }
}
