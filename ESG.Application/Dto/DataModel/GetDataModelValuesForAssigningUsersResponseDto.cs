using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class GetDataModelValuesForAssigningUsersResponseDto
    {
        public List<DataModelDimenstionTypesWithValues> DataModelDimenstionTypesWithValues { get; set; }
        public List<DataModelValuesForAssigning> DataModelValuesForAssigning { get; set; }
    }
    public class DataModelDimenstionTypesWithValues
    {
        public long? TypeId { get; set; }
        public string? TypeName { get; set; }
        public List<DataModelDimenstionValues>? ValueIds { get; set; }
    }
    public class DataModelDimenstionValues
    {
        public long? DimensionValueId { get; set; }  
        public string? DimensionValueName { get; set; }
    }

    public class DataModelValuesForAssigning
    {
        public long DataModelValueId { get; set; }
        public long? DatapointId { get; set; }
        public string? DatapointName { get; set; }
        public string? DatapointCode { get; set; }
        public ModelDimensionHeadersDto? RowModelDimensionDto { get; set; }
        public ModelDimensionHeadersDto? ColumnModelDimensionDto { get; set; }
        public List<ModelDimensionHeadersDto>? FiltersDimensionDto { get; set; }
        public bool? IsBlocked { get; set; }
        public long? Accountable { get; set; }
        public long? Responsible { get; set; }

    }
    public class ModelDimensionHeadersDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}
