using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDataPointValueService
    {
        Task AddAsync(List<DatapointValueCreateRequestDto> DataPointValue);
        Task<DataPointValue> UpdateAsync(DataPointValue DataPointValue);
        Task<IEnumerable<DataPointValueResponseDto>> GetAll();
        
        Task<DataPointValue> GetById(long Id);
        Task DeleteDatapoint(long id);
    }
}
