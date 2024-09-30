using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class ModelFilterCombination
{
    public long Id { get; set; }

    public long DataModelId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DataModel DataModel { get; set; } = null!;

    public virtual ICollection<DataModelValue> DataModelValues { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();

    public virtual ICollection<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; } = new List<ModelFilterCombinationalValue>();

    public virtual IEnumerable<SampleModelFilterCombinationValue> SampleModelFilterCombinationValues { get; set; } = new List<SampleModelFilterCombinationValue>();
}
