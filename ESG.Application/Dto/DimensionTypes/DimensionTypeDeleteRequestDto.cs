﻿using ESG.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.DimensionTypes
{
    public class DimensionTypeDeleteRequestDto
    {

        public long Id { get; set; }
        public StateEnum State { get; set; }
    }
}
