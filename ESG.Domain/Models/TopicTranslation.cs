using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Enum;

namespace ESG.Domain.Models
{
    public partial class TopicTranslation
    {
        public long Id { get; set; }

        public string? ShortText { get; set; }

        public string? LongText { get; set; }

        public long LanguageId { get; set; }

        public long TopicId { get; set; }

        public StateEnum State { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public virtual Topic Topic { get; set; } = null!;        
        public virtual Language Language { get; set; } = null!;
    }
}
