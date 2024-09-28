using ESG.Application.Dto.DimensionTypes;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimentionTypeService
    {
        Task AddAsync(List<DimensionTypeCreateRequestDto> dimentionType);
        Task UpdateAsync(DimensionTypeUpdateRequestDto dimentionType);
        Task<IEnumerable<DimensionTypeResponseDto>> GetAll();
        Task<DimensionType> GetById(long Id);
        Task SoftDelete(DimensionTypeDeleteRequestDto request);
    }
}
