﻿using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class UnitOfMeasure : AuditableWithBaseEntityAndOrganization<long>
    {

        public long UnitOfMeasureTypeId { get; set; }
        public string ShortText { get; set; } = string.Empty;
        public string LongText { get; set; } = string.Empty;
        public UnitOfMeasureType UnitOfMeasureTypes { get; set; }
        public ICollection<UnitOfMeasureTranslations> UnitOfMeasureTranslations { get; set; }

    }
}
