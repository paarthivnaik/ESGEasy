using ESG.Application.Dto.DatapointType;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDatapointTypesService
    {
        Task AddAsync(List<DatapointTypeCreateRequestDto> datapointTypes);
        Task<DataPointType> UpdateAsync(DataPointType datapointTypes);
        Task<IEnumerable<DataPointType>> GetAll();
        Task<DataPointType> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
