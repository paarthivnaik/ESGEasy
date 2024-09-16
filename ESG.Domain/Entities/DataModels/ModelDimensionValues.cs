using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class ModelDimensionValues : AuditableWithBaseEntity<long>
    {
        public long ModelDimensionTypesId { get; set; }
        public ModelDimensionTypes ModelDimensionTypes { get; set; }
        public long DimensionsId { get; set; }
        public Dimensions Dimensions { get; set; }
    }
}
