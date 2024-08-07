using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Language:BaseEntity<long>
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}
