using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DimensionTypes
{
    public class DimensionTypeCreateRequestDto
    {
        public long DimensionTypeId { get; set; }
        public string Code { get; set; }
        public long OrganizationId { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        public bool isHierarchical { get; set; }
        public StateEnum State { get; set; }
        public long UserId { get; set; }
        //public long IsHeirarchialDimension { get; set; }
    }
}
