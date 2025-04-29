using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;

namespace ESG.Application.Services
{
    public class DisclosureRequirementTranslationService : IDisclosureRequirementTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DisclosureRequirementTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslations(long? langId)
        {            
            var list = await _unitOfWork.DisclosureRequirementRepo.GetDisclosureRequirementsTranslations(langId);
            var orderedList = list.OrderBy(u => u.Id);           
            return orderedList;
        }
        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslationsById(long? langId,long id)
        {            
            var list = await _unitOfWork.DisclosureRequirementRepo.GetDisclosureRequirementsTranslationsById(langId,id);
            var orderedList = list.OrderBy(u => u.Id);            
            return orderedList;
        }
    }
}
