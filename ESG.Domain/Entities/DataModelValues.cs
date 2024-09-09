using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DataModelValues : AuditableWithBaseEntity<long>
    {
        public long RowId { get; set; }
        public Dimensions Row { get; set; }
        public long ColumnId { get; set; }
        public Dimensions Column { get; set; }
        public long CombinationId { get; set; }
        public ModelFilterCombinationalValues Combination { get; set; }
        public string Value { get; set; }
    }
}
