using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.UnitOfMeasure
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
