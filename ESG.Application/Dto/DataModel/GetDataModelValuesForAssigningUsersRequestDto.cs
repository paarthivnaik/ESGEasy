using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class GetDataModelValuesForAssigningUsersRequestDto
    {
        public long DataModelId { get; set; }
        public long OrganizationId { get; set; }

    }
}
