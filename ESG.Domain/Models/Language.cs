using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Language
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string IsoCode { get; set; } = null!;

    public long? OrganizationId { get; set; }

    public virtual ICollection<DataPointType> DataPointTypes { get; set; } = new List<DataPointType>();

    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();

    public virtual ICollection<DatapointTypeTranslation> DatapointTypeTranslations { get; set; } = new List<DatapointTypeTranslation>();

    public virtual ICollection<DatapointValueTranslation> DatapointValueTranslations { get; set; } = new List<DatapointValueTranslation>();

    public virtual ICollection<DimensionTranslation> DimensionTranslations { get; set; } = new List<DimensionTranslation>();

    public virtual ICollection<DimensionTypeTranslation> DimensionTypeTranslations { get; set; } = new List<DimensionTypeTranslation>();

    public virtual ICollection<DimensionType> DimensionTypes { get; set; } = new List<DimensionType>();

    public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();

    public virtual ICollection<DisclosureRequirement> DisclosureRequirements { get; set; } = new List<DisclosureRequirement>();

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<Standard> Standards { get; set; } = new List<Standard>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual ICollection<UnitOfMeasureTranslation> UnitOfMeasureTranslations { get; set; } = new List<UnitOfMeasureTranslation>();

    public virtual ICollection<UnitOfMeasureTypeTranslation> UnitOfMeasureTypeTranslations { get; set; } = new List<UnitOfMeasureTypeTranslation>();

    public virtual ICollection<UnitOfMeasureType> UnitOfMeasureTypes { get; set; } = new List<UnitOfMeasureType>();

    public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; } = new List<UnitOfMeasure>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
