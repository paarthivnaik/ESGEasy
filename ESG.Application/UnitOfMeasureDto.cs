using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application
{
    public class UnitOfMeasureDto
    {
        public long Id { get; set; }
        public long UnitOfMeasureTypeId { get; set; }
        public string ShortText { get; set; } = string.Empty;
        public string LongText { get; set; } = string.Empty;
    }
}
