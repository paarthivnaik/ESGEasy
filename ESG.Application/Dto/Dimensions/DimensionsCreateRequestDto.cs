using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Dimensions
{
    public class DimensionsCreateRequestDto
    {
        public long DimensionsId { get; set; }
        public string Code { get; set; }
        public long OrganizationaId { get; set; }
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public long UserId { get; set; }
        public long IsHeirarchialDimension { get; set; }
        public long DimentionTypeId { get; set; }
        public StateEnum State { get; set; }
    }
}
