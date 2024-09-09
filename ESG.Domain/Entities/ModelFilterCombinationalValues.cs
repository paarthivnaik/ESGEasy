
using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class ModelFilterCombinationalValues : AuditableWithBaseEntity<long>
    {
        public long ModelFilterCombinationsId { get; set; }
        public ModelFilterCombinations ModelFilterCombinations { get; set; }
        public long ModelFilterId { get; set; }
        public DimensionType ModelFilter;
        public long DimensionsId { get; set; }
        public Dimensions Dimensions { get; set; }
    }
}
