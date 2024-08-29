using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public  class DisclosureRequirement : AuditableWithBaseEntity<long>
    {
        public string Code { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId  { get; set; }
        public Language Language { get; set; }
        public long? StandardId  { get; set; }
        public Standard Standard { get; set; }
        public IEnumerable<DataPointValues> DataPoints { get; set; }
    }
}
