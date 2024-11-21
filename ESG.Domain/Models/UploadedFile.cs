using System;
using System.Collections.Generic;

namespace ESG.Domain.Models;

public partial class UploadedFile
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? UploadDate { get; set; }

    public long? UserId { get; set; }

    public long? DataModelValueId { get; set; }

    public bool? IsDefaultModel { get; set; }

    public virtual DataModelValue? DataModelValue { get; set; }

    public virtual User? User { get; set; }
}
