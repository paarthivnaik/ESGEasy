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
        Task<DataPointValues> AddAsync(DataPointValues datapointValues);
        Task<DataPointValues> UpdateAsync(DataPointValues datapointValues);
        Task<IEnumerable<DataPointValues>> GetAll();
        Task<DataPointValues> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
