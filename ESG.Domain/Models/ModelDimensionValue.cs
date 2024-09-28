using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class ModelDimensionValue
{
    public long Id { get; set; }

    public long ModelDimensionTypesId { get; set; }

    public long DimensionsId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Dimension Dimensions { get; set; } = null!;

    public virtual ModelDimensionType ModelDimensionTypes { get; set; } = null!;
}
