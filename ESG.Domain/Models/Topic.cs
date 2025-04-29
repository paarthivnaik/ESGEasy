using ESG.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Topic
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string? ShortText { get; set; } = null!;

    public string LongText { get; set; } = null!;

    public long LanguageId { get; set; }

    public StateEnum State { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<Standard> Standards { get; set; } = new List<Standard>();
    public virtual ICollection<TopicTranslation> TopicTranslations { get; set; } = new List<TopicTranslation>();
    
}
