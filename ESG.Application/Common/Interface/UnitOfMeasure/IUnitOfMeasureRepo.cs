using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.UnitOfMeasure
{
    public interface IUnitOfMeasureRepo:IGenericRepository<Domain.Models.UnitOfMeasure>
    {
        public Task<IEnumerable<UnitOfMeasureTranslation>> GetAllUOMTranslationsByUOMId(long id);
        public Task<IEnumerable<Domain.Models.UnitOfMeasure>> GetAllUOMDetails(long organizationId);
    }
}
