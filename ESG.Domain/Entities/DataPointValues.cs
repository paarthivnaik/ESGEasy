﻿using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class DataPointValues : AuditableWithBaseEntityAndOrganization<long>
    {
        public string Name { get; set; }
        public long DatapointTypeId { get; set; }
        public DataPointTypes DataPointType { get; set; }
        public long? UnitOfMeasureTypeId { get; set; }
        public long? CurrencyId { get; set; }
        public bool? IsNarrative { get; set; }
        //public string Value { get; set; }
        public string Purpose { get; set; }
        public long LanguageId { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public Currency Currency { get; set; }
        public Language Language { get; set; }
        public IEnumerable<DatapointTypeTranslations> DatapointTypeTranslations { get; set; }
    }
}
