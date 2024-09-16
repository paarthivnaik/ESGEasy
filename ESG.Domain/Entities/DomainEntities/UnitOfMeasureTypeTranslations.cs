using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DomainEntities
{
    public class UnitOfMeasureTypeTranslations : AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }
        public long UnitOfMeasureTypeId { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public string ShortText { get; set; } = string.Empty;
        public string LongText { get; set; } = string.Empty;
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public StateEnum State { get; set; }

        public long CreatedBy { get; set; }
    }
}
