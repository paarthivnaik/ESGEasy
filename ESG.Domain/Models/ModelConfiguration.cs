using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class ModelConfiguration
{
    public long Id { get; set; }

    public long DataModelId { get; set; }

    public long RowId { get; set; }

    public long? ColumnId { get; set; }

    public ModelViewTypeEnum ViewType { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DimensionType? Column { get; set; }

    public virtual DataModel DataModel { get; set; } = null!;

    public virtual ICollection<DataModelFilter> DataModelFilters { get; set; } = new List<DataModelFilter>();

    public virtual DimensionType Row { get; set; } = null!;
}
