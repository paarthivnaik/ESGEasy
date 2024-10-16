using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DimensionType
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string? ShortText { get; set; }

    public string LongText { get; set; } = null!;

    public long LanguageId { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DataModelFilter> DataModelFilterDimensionTypes { get; set; } = new List<DataModelFilter>();

    public virtual ICollection<DataModelFilter> DataModelFilterFilters { get; set; } = new List<DataModelFilter>();

    public virtual ICollection<DimensionTypeTranslation> DimensionTypeTranslations { get; set; } = new List<DimensionTypeTranslation>();

    public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<ModelConfiguration> ModelConfigurationColumns { get; set; } = new List<ModelConfiguration>();

    public virtual ICollection<ModelConfiguration> ModelConfigurationRows { get; set; } = new List<ModelConfiguration>();

    public virtual ICollection<ModelDimensionType> ModelDimensionTypes { get; set; } = new List<ModelDimensionType>();

    public virtual ICollection<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; } = new List<ModelFilterCombinationalValue>();

    public virtual Organization Organization { get; set; } = null!;
}
