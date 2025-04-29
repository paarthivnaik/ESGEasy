using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESG.Application.Common.Interface.DisclosureRequirement;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.Infrastructure.Persistence.DisclosureRequirementRepo
{
    public class DisclosureRequirementRepo : GenericRepository<DisclosureRequirement>,IDisclosureRequirementRepo
    {
        private readonly ApplicationDbContext _context;
        public DisclosureRequirementRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementsTranslations(long? langId)
        {
            var list = await _context.DisclosureRequirements
                .Where(dr=> dr.State == Domain.Enum.StateEnum.active)                
                .Select(u => new DisclosureRequirement
                {
                    Id = u.Id,
                    Code = u.Code,                    
                    LanguageId = (long)langId,                   
                    State = u.State,
                    ShortText = u.DisclosureRequirementTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault(),
                    LongText = u.DisclosureRequirementTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetDisclosureRequirementsTranslationsById(long? langId, long? Id)
        {
            var list = await _context.DisclosureRequirements
                .Where(dr=>dr.Id == Id)                
                .Select(u => new DisclosureRequirement
                {
                    Id = u.Id,
                    Code = u.Code,
                    StandardId = u.StandardId,
                    LanguageId = (long)langId,                    
                    State = u.State,
                    ShortText = u.DisclosureRequirementTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.ShortText)
                    .FirstOrDefault(),
                    LongText = u.DisclosureRequirementTranslations
                    .Where(t => t.LanguageId == langId)
                    .Select(t => t.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Domain.Models.DisclosureRequirement>> GetAllDisclosureRequirements(Expression<Func<Domain.Models.DisclosureRequirement, bool>> predicate)
        {
            var list = await _context.DisclosureRequirements
                .Where(predicate)
                .Include(x => x.DisclosureRequirementTranslations)
                .ToListAsync();
            return list;
        }
    }
}
