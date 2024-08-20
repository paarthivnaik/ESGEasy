using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Currency:BaseEntity<long>
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string? ShortText { get; set; }
        public string LongText { get; set; }
        public ICollection<DataPointValues> DataPointValues { get; set; }

    }
}
