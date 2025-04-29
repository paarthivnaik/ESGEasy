using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Enum;

namespace ESG.Domain.Models
{
    public class LanguageTranslation
    {
        public long Id { get; set; }
        public string? Name { get; set; } = null;
        public long LanguageId { get; set; }
        public StateEnum State { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public virtual Language Language { get; set; } = null!;
    }
}
