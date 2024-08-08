using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDatapointTypesService
    {
        Task<DataPointTypes> AddAsync(DataPointTypes datapointTypes);
        Task<DataPointTypes> UpdateAsync(DataPointTypes datapointTypes);
        Task<IEnumerable<DataPointTypes>> GetAll();
        Task<DataPointTypes> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
