using ESG.Application.Dto.UnitOfMeasure;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.UnitOfMeasure
{
    public interface IUnitOfMeasureRepo:IGenericRepository<ESG.Domain.Entities.UnitOfMeasure>
    {
        public Task<IEnumerable<UnitOfMeasureTranslations>> GetAllUOMTranslations(long id);
    }
}
