using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Hierarchy : BaseEntity<long>
    {
        public long NodeId { get; set; }

        public NodeType NodeType { get; set; }
        public long ChildId { get; set; }
        public Dimensions Dimension { get; set; }
        public long DatapointId { get; set; }
        public DataPointTypes DataPointTypes { get; set; }
    }
    public enum NodeType
    {
        Dimensions,
        DimensionType
    }
}
