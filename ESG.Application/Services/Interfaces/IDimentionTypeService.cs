using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimentionTypeService
    {
        Task AddAsync(DimensionType dimentionType);
        Task<DimensionType> UpdateAsync(DimensionType dimentionType);
        Task<IEnumerable<DimensionType>> GetAll();
        Task<DimensionType> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
