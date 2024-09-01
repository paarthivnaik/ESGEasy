using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DataModel : AuditableWithBaseEntityAndOrganization<long>
    {
        public long? ModelId { get; set; }
        public IEnumerable<ModelDatapoints> ModelDatapoints { get; set; }
        public IEnumerable<ModelDimensionTypes> ModelDimensionTypes { get; set; }
        public IEnumerable<ModelDimensionValues> ModelDimensionValues { get; set; }
        public IEnumerable<ModelConfiguration> ModelConfiguration { get; set; }

    }
}
