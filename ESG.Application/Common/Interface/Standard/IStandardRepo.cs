using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Common.Interface.Standard
{
    public interface IStandardRepo : IGenericRepository<Domain.Models.Standard>
    {
        Task<IEnumerable<Domain.Models.Standard>> GetStandardTranslationsById(long? id, long organizationId, long? languageId);
        //Task<IEnumerable<Domain.Models.Standard>> GetAllStandards(long Id);
        Task<IEnumerable<Domain.Models.Standard>> GetAllStandards(Expression<Func<Domain.Models.Standard, bool>> predicate);
    }
}
