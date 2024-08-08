﻿using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Entities
{
    public class Organization:AuditableWithBaseEntity<long>
    {
        public string Name { get; set; }
        public string RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string? LatsName { get; set; }
        public string? StreetAddress { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? LogoUrl { get; set; }
        public long TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public long LanguageId { get; set; }
        public Language Languages { get; set; }
    }
}
