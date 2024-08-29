using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Language:BaseEntity<long>
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; }
        public virtual ICollection<UnitOfMeasureTranslations> UnitOfMeasureTranslations { get; set; }
        public virtual ICollection<UnitOfMeasureType> UnitOfMeasureTypes { get; set; }
        public virtual ICollection<UnitOfMeasureTypeTranslations> UnitOfMeasureTypeTranslations { get; set; }
        public virtual ICollection<Dimensions> Dimensions { get; set; }
        public virtual ICollection<DimensionTranslations> DimensionTranslations { get; set; }
        public virtual ICollection<DimensionType> DimensionTypes { get; set; }
        public virtual ICollection<DimensionTypeTranslations> DimensionTypeTranslations { get; set; }
        public virtual ICollection<DataPointTypes> DataPointTypes { get; set; }
        public virtual ICollection<DatapointTypeTranslations> DatapointTypeTranslations { get; set; }
        public virtual ICollection<DataPointValues> DataPointValues { get; set; }
        public virtual ICollection<DatapointValueTranslations> DatapointValueTranslations { get; set; }
        public virtual ICollection<Topic> ESGTopics { get; set; }
        public virtual ICollection<Standard> ESGStandards { get; set; }
        public virtual ICollection<DisclosureRequirement> DisclosureRequirements { get; set; }

    }
}
