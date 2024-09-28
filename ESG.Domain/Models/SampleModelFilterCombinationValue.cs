using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class SampleModelFilterCombinationValue
{
    public long Id { get; set; }

    public long DataModelFiltersId { get; set; }

    public long DimensionsId { get; set; }

    public long ModelFilterCombinationsId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DataModelFilter DataModelFilters { get; set; } = null!;

    public virtual Dimension Dimensions { get; set; } = null!;

    public virtual ModelFilterCombination ModelFilterCombinations { get; set; } = null!;
}
