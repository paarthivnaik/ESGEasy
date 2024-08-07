using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Common
{
    public  abstract class BaseEntityWithOrganization<T>
    {
        public virtual T Id { get; set; }
        public virtual T OrganizationId { get; set; }
    }
}
