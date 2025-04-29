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
    public class CurrencyTranslationService : ICurrencyTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CurrencyTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Currency>> GetCurrencyTranslations(long? languageId)
        {
            var list = await _unitOfWork.CurrencyRepo.GetCurrenciesTranslations(languageId);
            return list;
        }
    }
}
