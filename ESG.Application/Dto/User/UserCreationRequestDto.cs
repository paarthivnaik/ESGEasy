using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Dto.User
{
    public class UserCreationRequestDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; } = null;
        //public byte[] Password { get; set; }
        public string Password { get; set; }
        //public Guid SecurityStamp { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long LanguageId { get; set; }
        public long OrganizationId { get; set; }
        public long RoleId { get; set; }
        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
