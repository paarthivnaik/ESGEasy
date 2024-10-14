using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DatapointValue
{
    public class DataPointValueResponseDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public StateEnum State { get; set; }
        public long? DatapointTypeId { get; set; }
        public long? UnitOfMeasureId { get; set; }
        public long? CurrencyId { get; set; }
        public bool? IsNarrative { get; set; }
        public string? Purpose { get; set; }
        public long? LanguageId { get; set; }
        public long? UserId { get; set; }
        public long? DisclosureRequirementId { get; set; }
        public long? OrganizationId { get; set; }
    }
}
