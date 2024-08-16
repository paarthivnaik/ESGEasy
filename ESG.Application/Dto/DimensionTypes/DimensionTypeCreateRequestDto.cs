using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DimensionTypes
{
    public class DimensionTypeCreateRequestDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public bool IsHeirarchialDimention { get; set; }
        public bool IsActive { get; set; }

    }
}
