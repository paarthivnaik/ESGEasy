using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.UnitOfMeasure
{
    public class UnitOfMeasureResponseDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        //public string Name { get; set; }
        public string ShortText { get; set; } = string.Empty;
        public string LongText { get; set; } = string.Empty;
        public long LanguageId { get; set; }
        public StateEnum State { get; set; }
        public long UserId { get; set; }
        public long? OrganizationId { get; set; }
        public long? UOMTypeId { get; set; }
        public string? UomTypeName { get; set; }
    }
}
