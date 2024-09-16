using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.DisclosureRequirement;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.Hierarchies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DisclosureRequirementService : IDisclosureRequirementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DisclosureRequirementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DisclosureRequirementResponseDto>> GetAll()
        {
            var disreq = await _unitOfWork.Repository<DisclosureRequirement>().GetAll();
            return _mapper.Map<IEnumerable<DisclosureRequirementResponseDto>>(disreq);
        }
    }
}
