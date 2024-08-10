using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Entities;

namespace ESG.Application.Services.Interfaces
{
    public interface IUnitOfMeasureService
    {
        Task Add(UnitOfMeasureCreateRequestDto unitOfMeasure);
        Task AddRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure);
        Task Update(UnitOfMeasureUpdateRequestDto unitOfMeasure);
        //Task UpdateRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure);
        //Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll();
        Task<long> Count();
        //Task<List<UnitOfMeasure>> GetAllUOMs(long id);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMByUOMTypeId(long uomTypeId);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslations(long id);
        Task DeleteUOM(UnitOfMeasureDeleteRequest deleteRequest);
    }
}
