using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DimensionTypeTranslation
{
    public long DimensionTypeId { get; set; }

    public long LanguageId { get; set; }

    public string ShortText { get; set; } = null!;

    public string LongText { get; set; } = null!;

    public long CreatedBy { get; set; }

    public long Id { get; set; }

    public int State { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DimensionType DimensionType { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
