using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Enum;

namespace ESG.Application.Dto.Organization
{
    public class OrganizationCreateDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string RegistrationId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LatsName { get; set; }

        public string? StreetAddress { get; set; }

        public string? StreetNumber { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string Email { get; set; }

        public string? LogoUrl { get; set; }

        public long TenantId { get; set; }

        public long LanguageId { get; set; }

        public StateEnum State { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}