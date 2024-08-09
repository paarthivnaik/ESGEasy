using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto
{
    public class DimensionsDto
    {
        public long Id { get; set; }
        public long OrganizationaId { get; set; }
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public long IsHeirarchialDimension { get; set; }
        public long DimentionTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
