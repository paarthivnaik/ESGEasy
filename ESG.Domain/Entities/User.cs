using ESG.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace ESG.Domain.Entities
{
    public  class User:AuditableWithBaseEntity<long>
    {
       

        public byte[] Password { get; set; }

        public Guid SecurityStamp { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public bool Active { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime PasswordExpiry { get; set; }
    }
}
