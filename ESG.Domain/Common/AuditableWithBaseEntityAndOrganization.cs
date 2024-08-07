using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Common
{
    public abstract class AuditableWithBaseEntityAndOrganization<T> : BaseEntityWithOrganization<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; } = false;
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set ; }
    }
}
