using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;
    
public partial class DatapointTypeTranslation
{
    public long Id { get; set; }

    public string? ShortText { get; set; }

    public string? LongText { get; set; }

    public long LanguageId { get; set; }

    public long DatapointTypeId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual DataPointType DatapointType { get; set; } = null!;

    public virtual DataPointValue DatapointTypeNavigation { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
