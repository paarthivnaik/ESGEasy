﻿using ESG.Application.Dto.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyResponseDto>> GetAll();
    }
}