using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataModelsResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public List<DatapointsDto>? Datapoints { get; set; }
        public FactViewDto? FactView { get; set; } 
        public NarrativeViewDto? NarrativeView { get; set; }
    }
    public class DatapointsDto
    {
        public long Id { get; set; }
        public string? ShortText { get; set; }
    } 
    public class FactViewDto
    {
        public DimensionTypeDto RowDimension { get; set; }
        public DimensionTypeDto? ColumnDimension { get; set; }
        public List<DimensionTypeDto>? FilterDimension { get; set; }
    }

    public class NarrativeViewDto
    {
        public DimensionTypeDto RowDimension { get; set; } 
        public List<DimensionTypeDto>? FilterDimension { get; set; } 
    }

    public class DimensionTypeDto
    {
        public long DimensionTypeId { get; set; }
        public string DimensionTypeName { get; set; } 
        public List<DimensionValueDto>? DimensionValues { get; set; } 
    }

    public class DimensionValueDto
    {
        public long DimensionValueId { get; set; }
        public string DimensionValueName { get; set; }
    }

}
