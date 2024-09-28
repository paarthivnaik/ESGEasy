﻿using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class OrganizationHeirarchy
{
    public long Id { get; set; }

    public long HierarchyId { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Organization Organization { get; set; } = null!;
}
