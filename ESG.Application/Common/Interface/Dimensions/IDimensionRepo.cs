using ESG.Application.Dto.Dimensions;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Dimensions
{
    public interface IDimensionRepo
    {
        Task<IEnumerable<DimensionTranslations>> GetAllTranslations(long id);
    }
}
