using ESG.Application.Dto.Dimension;
using ESG.Domain.Enum;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionService
    {
        Task AddAsync(List<DimensionCreateRequestDto> dimentions);
        Task UpdateAsync(DimensionUpdateRequestDto dimentions);
        Task<IEnumerable<DimensionResponseDto>> GetAll(long organizationId);
        Task<IEnumerable<DimensionResponseDto>> GetById(long Id, long organizationId);
        Task Delete(DimensionDeleteRequestDto request);
        Task<IEnumerable<DimensionResponseDto>> GetAllTranslations(long id);        
        public Task<IEnumerable<object>> GetCount();
    }
}
