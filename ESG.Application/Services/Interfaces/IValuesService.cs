using ESG.Application.Dto.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IValuesService
    {
        Task<IEnumerable<GetTranslationsResponseDto>> GetMethod(int tableType, long typeId, long? valueId);
    }
}
