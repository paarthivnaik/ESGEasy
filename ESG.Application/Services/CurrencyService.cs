using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Currency;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyResponseDto>> GetAll()
        {
            var currencies = await _unitOfWork.Repository<Currency>().GetAll();
            return _mapper.Map<IEnumerable<CurrencyResponseDto>>(currencies);
        }
    }
}
