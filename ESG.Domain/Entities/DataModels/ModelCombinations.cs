using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DataModels
{
    public class ModelCombinations : AuditableWithBaseEntity<long>
    {
        public long DataPointValuesId { get; set; }
        public List<DataPointValues> DataPointValues { get; set; }
        public long DataModelId { get; set; }
        public List<DataModel> DataModel { get; set; }
        public IEnumerable<ModelFilterCombinationalValues> ModelFilterCombinationalValues { get; set; }
    }
}
