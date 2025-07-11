﻿using ESG.Application.Dto.DataPointValueTranslation;
using ESG.Application.Dto.UOMTranslations;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDataPointValueTranslationService
    {
        Task Add(DataPointValueTranslationCreateRequestDto requestDto);
        Task<IEnumerable<DataPointValue>> GetAllDatapointValuesTranslations(long? organizationId, long? langId);
    }
}
