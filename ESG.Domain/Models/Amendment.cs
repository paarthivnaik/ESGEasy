using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Amendment
{
    public int Id { get; set; }

    public long? FilterCombinationId { get; set; }

    public string? Value { get; set; }

    public long DatapointId { get; set; }

    public long? OrganizationId { get; set; }

    public virtual DataPointValue Datapoint { get; set; } = null!;

    public virtual ModelFilterCombination? FilterCombination { get; set; }

    public virtual Organization? Organization { get; set; }
}
