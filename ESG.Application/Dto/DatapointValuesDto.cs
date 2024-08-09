using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto
{
    public class DatapointValuesDto
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string Name { get; set; }
        public long DatapointTypeId { get; set; }
        public bool IsUOM { get; set; }
        public bool IsCurrency { get; set; }
        public bool IsNarrative { get; set; }
        public string Value { get; set; }
        public string Purpose { get; set; }
        public long LanguageId { get; set; }
        public bool IsActive { get; set; }
    }
}
