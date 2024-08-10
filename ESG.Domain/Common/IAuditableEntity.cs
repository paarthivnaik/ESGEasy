using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Common
{
    public interface IAuditableEntity
    {
        StateEnum State { get; set; }
        long CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        long? LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }

    }
}
