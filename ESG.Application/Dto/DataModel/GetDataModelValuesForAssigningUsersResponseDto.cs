using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class GetDataModelValuesForAssigningUsersResponseDto
    {
        public List<DataModelDimenstionTypesWithNamesForHeaders> DataModelDimenstionTypesWithNames { get; set; }
        public List<DataModelValuesForAssigning> DataModelValuesForAssigning { get; set; }
    }
    public class DataModelDimenstionTypesWithNamesForHeaders
    {
        public long? TypeId { get; set; }
        public string? TypeName { get; set; }
    }
    //public class DataModelDimenstionValues
    //{
    //    public long? DimensionValueId { get; set; }  
    //    public string? DimensionValueName { get; set; }
    //}

    public class DataModelValuesForAssigning
    {
        public long DataModelValueId { get; set; }
        public long? DatapointId { get; set; }
        public string? DatapointName { get; set; }
        public string? DatapointCode { get; set; }
        public List<DimensionalCombinationForDatapoint>? DimensionalCombinationForDatapoint { get; set; }
        public bool? IsBlocked { get; set; }
        public long? Accountable { get; set; }
        public long? Responsible { get; set; }
        public long? Consult {  get; set; }
        public long? Inform { get; set; }

    }
    public class DimensionalCombinationForDatapoint
    {
        public long? TypeId { get; set; }
        public long? ValueId { get; set; }
        public string? ValueName { get; set; }
    }
}
