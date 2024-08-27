using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DatapointValueTranslations : AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }
        public long DatapointValueId { get; set; }
        public DataPointValues DataPointValues { get; set; }
        //public string Value { get; set; }
        public string Purpose { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
