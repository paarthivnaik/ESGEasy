using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Tenant
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();
}
