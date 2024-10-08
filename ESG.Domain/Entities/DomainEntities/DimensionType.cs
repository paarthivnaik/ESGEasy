﻿using ESG.Domain.Common;
using ESG.Domain.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities.DomainEntities
{
    public class DimensionType : AuditableWithBaseEntityAndOrganization<long>
    {
        public string Code { get; set; }
        public string? ShortText { get; set; }
        public string LongText { get; set; }
        public long LanguageId { get; set; }
        //public bool IsType {  get; set; }
        public Language Language { get; set; }
        public IEnumerable<Dimensions> Dimensions { get; set; }
        public IEnumerable<ModelDimensionTypes> DimensionTypes { get; set; }
        public IEnumerable<ModelConfiguration> ModelConfigurations { get; set; }
        public IEnumerable<ModelFilterCombinationalValues> ModelFilterCombinationalValues { get; set; }
        public IEnumerable<DataModelFilters> DataModelFilters { get; set; }
    }
}
