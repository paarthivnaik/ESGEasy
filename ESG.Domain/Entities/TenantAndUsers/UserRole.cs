﻿using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.TenantAndUsers
{
    public class UserRole : AuditableWithBaseEntity<long>
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
