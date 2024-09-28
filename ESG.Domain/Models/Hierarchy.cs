using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Hierarchy
{
    public long Id { get; set; }

    public long HierarchyId { get; set; }

    public long DataPointValuesId { get; set; }

    public virtual DataPointValue DataPointValues { get; set; } = null!;
}
