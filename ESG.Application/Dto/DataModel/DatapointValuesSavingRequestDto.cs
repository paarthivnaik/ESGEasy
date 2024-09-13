﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DataModel
{
    public class DataPointValuesSavingRequestDto
    {
        public int UserId { get; set; }
        public int DatapointId { get; set; }
        public int ModelId { get; set; }
        public List<FilterCombinationsDto> FilterCombinations { get; set; }
    }

    public class FilterCombinationsDto
    {
        public List<FilterDto> Filters { get; set; }
        public List<DataDto> Data { get; set; }
    }

    public class FilterDto
    {
        public int TypeId { get; set; }
        public int ValueId { get; set; }
    }

    public class DataDto
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public string Value { get; set; }
    }


}