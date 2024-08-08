using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class OrganizatonsHierarchies : AuditableWithBaseEntity<long>
    {
        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public long HeirarchyId { get; set; }
        public IEnumerable<Heirarchy> Heirarchy { get; set; }
    }
}
