using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Dto;

namespace ESG.Application.Services.Interfaces
{
    public interface IUnitOfMeasureService
    {
        Task<int> Add(UnitOfMeasureDto unitOfMeasure);
        Task AddRange(IEnumerable<UnitOfMeasureDto> unitOfMeasure);
        Task Update(UnitOfMeasureDto unitOfMeasure);
        Task UpdateRange(IEnumerable<UnitOfMeasureDto> unitOfMeasure);
        Task<IEnumerable<UnitOfMeasureDto>> GetAll();
        Task<UnitOfMeasureDto> GetById(long Id);
        Task<long> Count();
    }
}
