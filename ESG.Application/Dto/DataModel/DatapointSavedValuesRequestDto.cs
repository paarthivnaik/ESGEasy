using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DatapointSavedValuesRequestDto
    {
        public long DatapointId { get; set; }
        public long UserId { get; set; }
        public long OrganizatonId { get; set; }
        public List<SavedDataPointFilters>? SavedDataPointFilters { get; set; }
    }
    public class SavedDataPointFilters
    {
        public long? TypeId { get; set; }
        public long? ValueId { get; set; }
    } 
}
