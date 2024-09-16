using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.Hierarchies
{
    public class Hierarchy : BaseEntity<long>
    {
        public long HierarchyId { get; set; }
        public long DataPointValuesId { get; set; }
        public DataPointValues DataPointValues { get; set; }
    }
}
