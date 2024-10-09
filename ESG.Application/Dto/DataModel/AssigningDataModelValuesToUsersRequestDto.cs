using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class AssigningDataModelValuesToUsersRequestDto
    {
        public long ModelId { get; set; }
        public long OrganizationId { get; set; }
        public List<AssigningUsersDto> AssigningUsersDtos { get; set; }
        
    }
    public class AssigningUsersDto
    {
        public long DataModelValueId { get; set; }
        public long? AccountableUserId { get; set; }
        public long? ResponsibleUserId { get; set; }
        public bool? IsBlocked { get; set; }
        public long? Inform {  get; set; }
        public long? Consult { get; set; }
    }
}
