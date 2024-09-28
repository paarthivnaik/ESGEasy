using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Value
{
    public interface IValuesRepo
    {
        Task<IEnumerable<UnitOfMeasureTranslation>> GetUOMTranslations(long? valueId);
        Task<IEnumerable<UnitOfMeasureTypeTranslation>> GetUOMTypeTranslations(long typeId);
        Task<IEnumerable<DimensionTranslation>> GetDimensionTranslations(long typeId, long? valueId);
        Task<IEnumerable<DimensionTypeTranslation>> GetDimensionTypeTranslation(long typeId);
        Task<IEnumerable<DatapointValueTranslation>> GetDatapointTranslations(long typeId, long? valueId);
        Task<IEnumerable<DatapointTypeTranslation>> GetDatapointTypeTranslations(long typeId);
    }
}
