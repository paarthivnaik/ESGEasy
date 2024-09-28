using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUnitOfMeasureTypeService
    {
        Task Add(List<UnitOfMeasureTypeCreateRequestDto> unitOfMeasureType);
        Task UpdateAsync(UnitOfMeasureTypeUpdateRequestDto unitOfMeasureType);
        Task AddAsync(UnitOfMeasureType unitOfMeasureType);
        Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAll();
        Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAllTranslations(long Id);
        Task DeleteUOMType(UnitOfMeasureTypeDeleteRequestDto unitOfMeasureType);
    }
}
