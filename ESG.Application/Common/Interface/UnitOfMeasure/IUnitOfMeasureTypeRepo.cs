using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Common.Interface.UnitOfMeasure
{
    public interface IUnitOfMeasureTypeRepo : IGenericRepository<Domain.Models.UnitOfMeasureType>
    {
        public Task<IEnumerable<Domain.Models.UnitOfMeasureType>> GetAllUOMTranslationsByUOMIdLangId(long langId, long organizationId);
    }
}
