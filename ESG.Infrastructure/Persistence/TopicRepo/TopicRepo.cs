using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.Topic;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.Infrastructure.Persistence.TopicRepo
{
    public class TopicRepo:GenericRepository<Topic>,ITopicRepo
    {
        private readonly ApplicationDbContext _context;
        public TopicRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Models.Topic>> GetTopicTranslationsByTopicId(long id, long organizationId, long? languageId)
        {
            var list = await _context.Topics
                .Where(t => t.Id == id)
                .Select(t => new Topic
                {
                    Id = t.Id,
                    Code = t.Code,                   
                    ShortText = t.TopicTranslations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.ShortText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            var result = await _context.Topics
                .Include(t => t.TopicTranslations)
                .ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Domain.Models.Topic>> GetTopicTranslations(Expression<Func<Domain.Models.Topic, bool>> predicate)
        {
            var list = await _context.Topics
                .Where(predicate)
                .Include(x => x.TopicTranslations)
                .ToListAsync();
            return list;
        }
    }
}
