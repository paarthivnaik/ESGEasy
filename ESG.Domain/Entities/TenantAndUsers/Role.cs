using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.TenantAndUsers
{
    public class Role : BaseEntity<long>
    {
        public string Name { get; set; }
        public IEnumerable<UserRole> Users { get; set; }
    }
}
