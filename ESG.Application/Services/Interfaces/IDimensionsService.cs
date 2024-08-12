using ESG.Application.Dto.Dimensions;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionsService
    {
        Task AddAsync(DimensionsCreateRequestDto dimentions);
        Task UpdateAsync(DimensionsUpdateRequestDto dimentions);
        Task<IEnumerable<DimensionsResponseDto>> GetAll();
        Task<IEnumerable<DimensionsResponseDto>> GetById(long Id);
        Task Delete(DimensionsDeleteRequestDto request);
        Task<IEnumerable<DimensionsResponseDto>> GetAllTranslations(long id);
    }
}
