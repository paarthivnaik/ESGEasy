using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DataModelFilters : AuditableWithBaseEntity<long>
    {
        public long ModelConfigurationId { get; set; }
        public ModelConfiguration ModelConfiguration { get; set; }
        public long FilterId { get; set; }
    }
}
