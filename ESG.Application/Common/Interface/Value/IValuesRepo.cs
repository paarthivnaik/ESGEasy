using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Value
{
    public interface IValuesRepo
    {
        Task<IEnumerable<ESG.Domain.Entities.UnitOfMeasureTranslations>> GetUOMTranslations(long? valueId);
        Task<IEnumerable<UnitOfMeasureTypeTranslations>> GetUOMTypeTranslations(long typeId);
        Task<IEnumerable<ESG.Domain.Entities.DimensionTranslations>> GetDimensionsTranslations(long typeId, long? valueId);
        Task<IEnumerable<DimensionTypeTranslations>> GetDimensionTypeTranslations(long typeId);
        Task<IEnumerable<DatapointValueTranslations>> GetDatapointTranslations(long typeId, long? valueId);
        Task<IEnumerable<DatapointTypeTranslations>> GetDatapointTypeTranslations(long typeId);
    }
}
