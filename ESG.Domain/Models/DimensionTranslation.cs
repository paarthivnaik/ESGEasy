using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DimensionTranslation
{
    public long DimensionsId { get; set; }

    public long LanguageId { get; set; }

    public string? ShortText { get; set; }

    public string? LongText { get; set; }

    public long CreatedBy { get; set; }

    public long Id { get; set; }

    public StateEnum State { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Dimension Dimensions { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
