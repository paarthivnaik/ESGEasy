using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class ModelConfiguration : AuditableWithBaseEntity<long>
    {
        public long DataModelId { get; set; }
        public DataModel DataModel { get; set; }
        public long RowId { get; set; } 
        public DimensionType Row { get; set; } 
        public long? ColumnId { get; set; }
        public DimensionType Column { get; set; } 
        public ModelViewTypeEnum ViewType { get; set; }
        public IEnumerable<DataModelFilters> DataModelFilters { get; set; }
    }
}
