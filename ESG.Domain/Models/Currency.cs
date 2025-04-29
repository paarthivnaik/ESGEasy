using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class Currency
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;
    public long LanguageId { get; set; } 
    public string? ShortText { get; set; }

    public string? LongText { get; set; } = null!;
    public virtual Language Language { get; set; } = null!;
    public virtual ICollection<DataPointValue> DataPointValues { get; set; } = new List<DataPointValue>();
    public virtual ICollection<CurrencyTranslation> CurrencyTranslations { get; set; } = new List<CurrencyTranslation>();
}
