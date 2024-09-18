using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Common;

namespace ESG.Domain.Entities.TenantAndUsers
{
    public partial class OrganizationUser : AuditableWithBaseEntity<long>
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }

    }
}
