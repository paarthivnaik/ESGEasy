using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DataModel
{
    public long Id { get; set; }

    public string? ModelName { get; set; }

    public string? Purpose { get; set; }

    public bool IsDefaultModel { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<DataModelValue> DataModelValues { get; set; } = new List<DataModelValue>();

    public virtual ICollection<DefaultDataModelValue> DefaultDataModelValues { get; set; } = new List<DefaultDataModelValue>();

    public virtual ICollection<ModelConfiguration> ModelConfigurations { get; set; } = new List<ModelConfiguration>();

    public virtual ICollection<ModelDatapoint> ModelDatapoints { get; set; } = new List<ModelDatapoint>();

    public virtual ICollection<ModelDimensionType> ModelDimensionTypes { get; set; } = new List<ModelDimensionType>();

    public virtual ICollection<ModelFilterCombination> ModelFilterCombinations { get; set; } = new List<ModelFilterCombination>();

    public virtual Organization Organization { get; set; } = null!;
}
