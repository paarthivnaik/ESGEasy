using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class UnitOfMeasureTypeTranslation
{
    public long UnitOfMeasureTypeId { get; set; }

    public long LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public string ShortText { get; set; } = null!;

    public string LongText { get; set; } = null!;

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public long Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual UnitOfMeasureType UnitOfMeasureType { get; set; } = null!;
}
