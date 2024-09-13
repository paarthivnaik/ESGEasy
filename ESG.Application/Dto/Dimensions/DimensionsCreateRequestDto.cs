using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Dimensions
{
    public class DimensionCreateRequestDto
    {
        public long DimensionsId { get; set; }
        public string Code { get; set; }
        public long OrganizationId { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public long UserId { get; set; }
        public long DimensionTypeId { get; set; }
        public StateEnum State { get; set; }
    }
}
