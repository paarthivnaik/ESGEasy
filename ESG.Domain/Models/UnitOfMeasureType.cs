using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class UnitOfMeasureType
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string? ShortText { get; set; }

    public string? LongText { get; set; }

    public long LanguageId { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;

    public virtual ICollection<UnitOfMeasureTypeTranslation> UnitOfMeasureTypeTranslations { get; set; } = new List<UnitOfMeasureTypeTranslation>();

    public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; set; } = new List<UnitOfMeasure>();
}
