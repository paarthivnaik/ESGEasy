﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }

        public string FileName { get; set; } = null!;

        public byte[]? FileData { get; set; } = null!;

        public DateTime UploadDate { get; set; }

        public long? UserId { get; set; }

        public long? DataModelValueId { get; set; }

        public bool? IsDefaultModel { get; set; }

        public virtual User? User { get; set; }
    }
}
