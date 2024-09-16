using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class ModelDatapoints : AuditableWithBaseEntity<long>
    {
        public long DataModelId { get; set; }
        public long DatapointValuesId { get; set; }
        public DataModel DataModel { get; set; }
        public DataPointValues DataPointValues { get; set; }
    }
}
