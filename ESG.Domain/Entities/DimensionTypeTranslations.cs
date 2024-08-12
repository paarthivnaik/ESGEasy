using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DimensionTypeTranslations : AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public string Code { get; set; }
        public long DimensionTypeId { get; set; }
        public DimensionType DimensionType { get; set; }
        public IEnumerable<Dimensions> Dimensions { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
