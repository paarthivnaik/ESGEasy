using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DataPointValue
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public long? DatapointTypeId { get; set; }

    public long? UnitOfMeasureId { get; set; }

    public long? CurrencyId { get; set; }

    public bool? IsNarrative { get; set; }

    public string? Purpose { get; set; }

    public long LanguageId { get; set; }

    public long? DisclosureRequirementId { get; set; }

    public long? UserId { get; set; }

    public long OrganizationId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? ShortText { get; set; }

    public string? LongText { get; set; }

    public virtual ICollection<Amendment> Amendments { get; set; } = new List<Amendment>();

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<DataModelValue> DataModelValues { get; set; } = new List<DataModelValue>();

    public virtual DataPointType? DatapointType { get; set; }

    //public virtual ICollection<DatapointTypeTranslation> DatapointTypeTranslations { get; set; } = new List<DatapointTypeTranslation>();

    public virtual ICollection<DatapointValueTranslation> DatapointValueTranslations { get; set; } = new List<DatapointValueTranslation>();

    public virtual DisclosureRequirement? DisclosureRequirement { get; set; }

    public virtual ICollection<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<ModelDatapoint> ModelDatapoints { get; set; } = new List<ModelDatapoint>();

    public virtual Organization Organization { get; set; } = null!;

    public virtual UnitOfMeasure? UnitOfMeasure { get; set; }

    public virtual User? User { get; set; }
}
