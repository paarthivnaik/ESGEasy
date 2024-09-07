using ESG.Application.Dto.DisclosureRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDisclosureRequirementService
    {
        Task<IEnumerable<DisclosureRequirementResponseDto>> GetAll();
    }
}
