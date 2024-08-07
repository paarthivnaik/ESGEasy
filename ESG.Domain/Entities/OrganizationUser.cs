using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Common;

namespace ESG.Domain.Entities
{
    public partial class OrganizationUser:AuditableWithBaseEntity<long>
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public  Organization Organizations { get; set; }

        public  User Users { get; set; }
    }
}
