using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Enums
{
    public enum LoginResultEnum
    {
        Success = 1,
        Failed = 2,
        Expired = 3,
        Locked = 4,
        Deleted = 5,
        RequiresSelection = 6,
        MissingRolesOrOrgs = 7,
    }
}
