using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Common.Interface.Dimensions
{
    public interface IDimensionTypeRepo
    {
        Task<IEnumerable<DimensionType>> GetDimensionTypeTranslations(long? laguageId,long? organizationId);
    }
}
