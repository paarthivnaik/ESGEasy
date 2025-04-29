using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.Standard;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.Infrastructure.Persistence.StandardRepo
{
    public class StandardRepo :GenericRepository<Standard>,IStandardRepo
    {
        private readonly ApplicationDbContext _context;
        public StandardRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Standard>> GetStandardTranslationsById(long? id, long organizationId, long? languageId)
        {
            var list = await _context.Standards
                .Where(s => s.Id == id)
                .Select(s => new Standard
                {
                    Id = s.Id,
                    Code = s.Code,
                    TopicId = s.TopicId,
                    ShortText = s.StandardTranslations
                    .Where(tt => tt.LanguageId == languageId)
                    .Select(tt => tt.ShortText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return list;

        }
        //public async Task<IEnumerable<Standard>> GetAllStandards(long Id)
        public async Task<IEnumerable<Domain.Models.Standard>> GetAllStandards(Expression<Func<Domain.Models.Standard, bool>> predicate)
        {
            var list = await _context.Standards
                .Where(predicate)
                .Include(st => st.StandardTranslations)
                .ToListAsync();
            return list;
        }
    }
}
