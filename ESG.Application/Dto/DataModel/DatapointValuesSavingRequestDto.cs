using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataPointValueSavingRequestDto
    {
        public long UserId { get; set; }
        public long DatapointId { get; set; }
        public long ModelId { get; set; }
        public long OrganizationId { get; set; }
        public string? Amendment { get; set; }
        public List<FilterDto>? FilterDtos { get; set; }
        public List<DataDto> DataDtos { get; set; }
    }

    public class FilterDto
    {
        public long TypeId { get; set; }
        public long ValueId { get; set; }
    }

    public class DataDto
    {

        public long RowId { get; set; }
        public long? ColumnId { get; set; }
        public string Value { get; set; }
    }


}
