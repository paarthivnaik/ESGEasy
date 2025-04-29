using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Models
{
    public partial class Country
    {
        public long Id { get; set; }
     
        public string CountryCode { get; set; } = null!;

        public string? ShortText { get; set; }

        public string LongText { get; set; } = null!;
        
    }
}
