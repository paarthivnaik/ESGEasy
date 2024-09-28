using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using ESG.Domain.Entities.TenantAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class DataModelValues : AuditableWithBaseEntity<long>
    {
        public long RowId { get; set; }
        public Dimensions Row { get; set; }
        public long? ColumnId { get; set; }
        public Dimensions Column { get; set; }
        public long CombinationId { get; set; }
        public ModelCombinations Combination { get; set; }
        public string? Value { get; set; }
        public bool? IsBlocked { get; set; }
        public long? ResponsibleUserId { get; set; }
        public User ResponsibleUser { get; set; }
        public long? AccountableUserId { get; set; }
        public User AccountableUser { get; set; }
    }
}
