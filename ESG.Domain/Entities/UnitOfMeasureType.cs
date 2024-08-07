using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class UnitOfMeasureType : AuditableWithBaseEntityAndOrganization<long>
    {

        public string Name { get; set; } = string.Empty;
        public IEnumerable<UnitOfMeasure> UnitOfMeasure { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
