using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Models;

namespace ESG.Application.Common.Interface.Topic
{
    public interface ITopicRepo:IGenericRepository<Domain.Models.Topic>
    {
        Task<IEnumerable<Domain.Models.Topic>> GetTopicTranslationsByTopicId(long id,long organizationId,long? languageId);
        Task<IEnumerable<Domain.Models.Topic>> GetAllTopics();
        Task<IEnumerable<Domain.Models.Topic>> GetTopicTranslations(Expression<Func<Domain.Models.Topic, bool>> predicate);
    }
}
