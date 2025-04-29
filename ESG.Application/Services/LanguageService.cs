using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Dimension;
using ESG.Application.Dto.Language;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;

namespace ESG.Application.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LanguageDto>> GetAll()
        {            
            var list = await _unitOfWork.Repository<Language>().GetAll();                
            return _mapper.Map<IEnumerable<LanguageDto>>(list);
        }
        public async Task<LanguageDto> GetById(long id)
        {            
            var list = await _unitOfWork.Repository<Language>().Get
                (l => l.Id == id);
            return _mapper.Map<LanguageDto>(list);
        }
        public async Task<IEnumerable<LanguageTranslation>> GetLanguageTranslationsByLanguageId(long languageId)
        {
            var list = await _unitOfWork.LanguageRepo.GetLanguagesByLanguageId(languageId);
            return list;            
        }
    }
}
