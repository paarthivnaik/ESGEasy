﻿using System;
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
        public string LastName { get; set; }
        //public byte[] Password { get; set; }
        public string Password { get; set; }
        //public Guid SecurityStamp { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long LanguageId { get; set; }
    }
}
