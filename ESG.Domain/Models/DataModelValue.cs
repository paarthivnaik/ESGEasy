using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DataModelValue
{
    public long Id { get; set; }

    public long RowId { get; set; }

    public long? ColumnId { get; set; }

    public long CombinationId { get; set; }

    public string? Value { get; set; }

    public bool? IsBlocked { get; set; }

    public long? ResponsibleUserId { get; set; }

    public long? AccountableUserId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public long? DataPointValuesId { get; set; }

    public virtual User? AccountableUser { get; set; }

    public virtual Dimension? Column { get; set; }

    public virtual ModelFilterCombination Combination { get; set; } = null!;

    public virtual DataPointValue? DataPointValues { get; set; }

    public virtual User? ResponsibleUser { get; set; }

    public virtual Dimension Row { get; set; } = null!;
}
