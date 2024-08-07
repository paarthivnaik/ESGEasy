using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class UserRole:AuditableWithBaseEntity<long>
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
        public  Role Roles { get; set; }
        public  User Users { get; set; }
    }
}
