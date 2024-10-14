using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Dimension
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string ShortText { get; set; } = null!;

    public string LongText { get; set; } = null!;

    public long LanguageId { get; set; }

    public long DimensionTypeId { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<DataModelValue> DataModelValueColumns { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataModelValue> DataModelValueRows { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DimensionTranslation> DimensionTranslations { get; set; } = new List<DimensionTranslation>();

    public virtual DimensionType DimensionType { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<ModelDimensionValue> ModelDimensionValues { get; set; } = new List<ModelDimensionValue>();

    public virtual ICollection<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; } = new List<ModelFilterCombinationalValue>();

    public virtual Organization Organization { get; set; } = null!;

    public virtual ICollection<SampleModelFilterCombinationValue> SampleModelFilterCombinationValues { get; set; } = new List<SampleModelFilterCombinationValue>();
}
