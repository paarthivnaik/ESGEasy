using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class AuditLog
{
    public long Id { get; set; }

    public long CreatedBy { get; set; }

    public string Type { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? AffectedColumns { get; set; }

    public string PrimaryKey { get; set; } = null!;
}
