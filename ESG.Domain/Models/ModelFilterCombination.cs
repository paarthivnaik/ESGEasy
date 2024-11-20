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

    public ModelViewTypeEnum? ViewType { get; set; }

    public virtual ICollection<Amendment> Amendments { get; set; } = new List<Amendment>();

    public virtual DataModel DataModel { get; set; } = null!;

    public virtual ICollection<DataModelValue> DataModelValues { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValues { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; } = new List<ModelFilterCombinationalValue>();

    public virtual ICollection<SampleModelFilterCombinationValue> SampleModelFilterCombinationValues { get; set; } = new List<SampleModelFilterCombinationValue>();
}
