using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.UnitOfMeasure
{
    public interface IUnitOfMeasureRepo:IGenericRepository<Domain.Entities.DomainEntities.UnitOfMeasure>
    {
        public Task<IEnumerable<UnitOfMeasureTranslations>> GetAllUOMTranslationsByUOMId(long id);
    }
}
