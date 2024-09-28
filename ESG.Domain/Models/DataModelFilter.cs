using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DataModelFilter
{
    public long Id { get; set; }

    public long ModelConfigurationId { get; set; }

    public long FilterId { get; set; }

    public long? DimensionTypeId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DimensionType? DimensionType { get; set; }

    public virtual DimensionType Filter { get; set; } = null!;

    public virtual ModelConfiguration ModelConfiguration { get; set; } = null!;

    public virtual ICollection<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; } = new List<ModelFilterCombinationalValue>();

    public virtual ICollection<SampleModelFilterCombinationValue> SampleModelFilterCombinationValues { get; set; } = new List<SampleModelFilterCombinationValue>();
}
