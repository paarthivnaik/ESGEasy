using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.UnitOfMeasure
{
    public class UnitOfMeasureCreateRequestDto
    {

        public string Code { get; set; }
        //public string? Name { get; set; }
        public long UnitOfMeasureTypeId { get; set; }
        public string? ShortText { get; set; } = string.Empty;
        public string? LongText { get; set; } = string.Empty;
        public long LanguageId { get; set; }
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public long UnitOfMeasureId { get; set; }
    }
}
