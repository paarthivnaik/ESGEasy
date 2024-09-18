using ESG.Domain.Common;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace ESG.Domain.Entities.TenantAndUsers
{
    public class User : AuditableWithBaseEntity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public byte[] Password { get; set; }
        public string Password { get; set; }
        public Guid SecurityStamp { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long LanguageId { get; set; }
        public Language Languages { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<OrganizationUser> OrganizationUsers { get; set; }
    }
}
