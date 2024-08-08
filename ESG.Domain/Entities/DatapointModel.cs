using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DatapointModel : AuditableWithBaseEntityAndOrganization<long>
    {
        public long DatapointId { get; set; }
        public long DimentionsId { get; set; }
        public SortingTypeEnum SortingType { get; set; }
        public DataPointTypes DataPointTypes { get; set; }
        public Dimensions Dimentions { get; set; }
    }
}
