using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Enum;

namespace ESG.Application.Services.Interfaces
{
    public interface IUnitOfMeasureService
    {
        Task Add(List<UnitOfMeasureCreateRequestDto> unitOfMeasure);
        Task AddRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure);
        Task Update(UnitOfMeasureUpdateRequestDto unitOfMeasure);
        //Task UpdateRange(IEnumerable<UnitOfMeasureCreateRequestDto> unitOfMeasure);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll(long organizationId);
        Task<long> Count();
        
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMByUOMTypeId(long uomTypeId);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslationsByUOMId(long id);
        Task DeleteUOM(UnitOfMeasureDeleteRequest deleteRequest);
    }
}
