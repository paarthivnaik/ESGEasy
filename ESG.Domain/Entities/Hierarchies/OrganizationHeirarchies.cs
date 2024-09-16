using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.Hierarchies
{
    public class OrganizationHeirarchies : AuditableWithBaseEntityAndOrganization<long>
    {
        public long HierarchyId { get; set; }
    }
}
