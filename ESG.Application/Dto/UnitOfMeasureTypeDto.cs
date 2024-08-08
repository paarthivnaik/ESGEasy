using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto
{
    public class UnitOfMeasureTypeDto
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string? Name { get; set; }
        public long LanguageId { get; set; }
        public bool IsActive { get; set; }
    }
}
