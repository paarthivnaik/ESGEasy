using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class DisclosureRequirement
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string ShortText { get; set; } = null!;

    public string LongText { get; set; } = null!;

    public long LanguageId { get; set; }

    public long? StandardId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();

    public virtual Language Language { get; set; } = null!;

    public virtual Standard? Standard { get; set; }
}
