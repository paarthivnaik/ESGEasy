using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Organization:AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }

        public long TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
