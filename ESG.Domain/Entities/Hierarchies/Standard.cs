using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.Hierarchies
{
    public class Standard : AuditableWithBaseEntity<long>
    {
        public string Code { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public IEnumerable<DisclosureRequirement> DisclosureRequirements { get; set; }
    }
}
