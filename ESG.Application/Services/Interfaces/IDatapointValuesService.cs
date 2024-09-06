﻿using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDatapointValuesService
    {
        Task AddAsync(DatapointValueCreateRequestDto datapointValues);
        Task<DataPointValues> UpdateAsync(DataPointValues datapointValues);
        Task<IEnumerable<DatapointValuesResponseDto>> GetAll();
        Task<DataPointValues> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
