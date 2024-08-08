using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Dimentions : AuditableWithBaseEntityAndOrganization<long>
    {
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public long DimentionTypeId { get; set; }
        public bool IsHeirarchialDimention { get; set; }
        public DimentionType DimentionType { get; set; }
        public IEnumerable<DataPointTypes> DataPointTypes { get; set; }
        public IEnumerable<DatapointModel> DatapointModels { get; set; }
    }
}
