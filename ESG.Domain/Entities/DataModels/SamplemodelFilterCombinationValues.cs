using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class SampleModelFilterCombinationValues : AuditableWithBaseEntity<long>
    {
        public long DataModelFiltersId { get; set; }
        public List<DataModelFilters> DataModelFilters { get; set; }
        public long DimensionsId { get; set; }
        public List<Dimensions> Dimensions;
        public long ModelFilterCombinationsId { get; set; }
        public List<ModelCombinations> ModelFilterCombinations { get; set; }
    }

}
