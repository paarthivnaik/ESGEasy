using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Dimension
{
    public class DimensionResponseDto
    {
        public long Id {  get; set; }
        public string Code { get; set; }
        //public string? Name { get; set; }
        public StateEnum State { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long UserId { get; set; }
        public long LanguageId { get; set; }
        public long? OrganizationId  { get; set; }
    }
}
