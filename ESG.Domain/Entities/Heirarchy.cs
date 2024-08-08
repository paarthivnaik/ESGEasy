using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Heirarchy : AuditableWithBaseEntityAndOrganization<long>
    {
        public long ParentDimention { get; set; }
        public DimensionType DimentionsTypes { get; set; }
        public long ChildDimention { get; set; }

        public Dimensions Dimentions { get; set; }
        public long DatapointId { get; set; }
        public IEnumerable<DataPointTypes> DataPointType { get; set; }
    }
}
