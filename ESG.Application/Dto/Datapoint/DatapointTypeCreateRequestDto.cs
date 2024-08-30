﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.Datapoint
{
    public class DatapointTypeCreateRequestDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public string ShortText { get; set; }
        public string LongText { get; set; }
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
    }
}