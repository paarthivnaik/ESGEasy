using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class ModelDimensionValues :AuditableWithBaseEntity<long>
    {
        public long DataModelId { get; set; }
        public DataModel DataModel { get; set; }
        public long DimensionsId { get; set; }
        public Dimensions Dimensions { get; set; }

    }
}
