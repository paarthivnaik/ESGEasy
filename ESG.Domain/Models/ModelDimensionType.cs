using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class ModelDimensionType
{
    public long Id { get; set; }

    public long DataModelId { get; set; }

    public long DimensionTypeId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DataModel DataModel { get; set; } = null!;

    public virtual DimensionType DimensionType { get; set; } = null!;

    public virtual ICollection<ModelDimensionValue> ModelDimensionValues { get; set; } = new List<ModelDimensionValue>();
}
