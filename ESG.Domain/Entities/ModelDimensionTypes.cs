using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class ModelDimensionTypes : AuditableWithBaseEntity<long>
    {
        public long DataModelId { get; set; }
        public DataModel DataModel { get; set; }
        public long DimensionTypeId { get; set; }
        public IEnumerable<DimensionType> DimensionType { get; set; }
        public IEnumerable<ModelDimensionValues> ModelDimensionValues { get; set; }
    }
}
