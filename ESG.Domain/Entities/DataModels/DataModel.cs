using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class DataModel : AuditableWithBaseEntityAndOrganization<long>
    {
        public string? ModelName { get; set; }
        public string? Purpose { get; set; }
        public bool IsDefaultModel { get; set; }
        public IEnumerable<ModelDatapoints> ModelDatapoints { get; set; }
        public IEnumerable<ModelDimensionTypes> ModelDimensionTypes { get; set; }
        public IEnumerable<ModelConfiguration> ModelConfiguration { get; set; }
        public IEnumerable<ModelCombinations> ModelCombinations { get; set; }
    }
}
