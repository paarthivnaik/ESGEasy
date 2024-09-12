
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
        public long DataModelFiltersId { get; set; }
        public DataModelFilters DataModelFilters { get; set; }
        public long DimensionsId { get; set; }
        public Dimensions Dimensions;
        public long ModelFilterCombinationsId { get; set; }
        public ModelCombinations ModelFilterCombinations { get; set; }
    }
}
