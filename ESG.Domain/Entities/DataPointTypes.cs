using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DataPointTypes : AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public IEnumerable<DataPointValues> DataPointValues { get; set; }
        public IEnumerable<DatapointTypeTranslations> DataPointTypeTranslations { get; set; }
    }
}
