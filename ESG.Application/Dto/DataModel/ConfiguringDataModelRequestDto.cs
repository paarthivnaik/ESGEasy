using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class ConfiguringDataModelRequestDto
    {
        public long UserId { get; set; }
        public long DataModelId { get; set; }
        public ModelViewTypeEnum ViewType {  get; set; } // 1-fact,  2-narrative
        public long RowId { get; set; }
        public long? ColumnId { get; set; }
        public List<long> FilterIds { get; set; }
    }
}
