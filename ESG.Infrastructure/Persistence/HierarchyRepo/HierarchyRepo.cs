using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Hierarchy;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.HierarchyRepo
{
    public class HierarchyRepo : GenericRepository<UnitOfMeasure>, IHierarchyRepo
    {
        private readonly ApplicationDbContext _context;
        public HierarchyRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> GetNextHierarchyIdAsync()
        {
            var maxHierarchyId = await _context.Hierarchies
                .AsNoTracking()
                .Select(a => (long?)a.HierarchyId) 
                .MaxAsync();
            return maxHierarchyId.HasValue ? maxHierarchyId.Value + 1 : 1; 
        }
        public async Task<long> GetHierarchyIdByOrgId(long organizationId)
        {
            
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(t => t.OrganizationId == organizationId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
             return hierarchyId;
            
        }
        public async Task<IEnumerable<Topic>> GetTopicTranslationsByLangId(long? languageId, long? organizationId, long? Id)
        {
            var list = await _context.Topics                
                .Select(t => new Topic
                {
                    Id = t.Id,
                    Code = t.Code,                    
                    LanguageId = (long)languageId,
                    State = t.State,
                    ShortText = t.TopicTranslations
                    .Where(t => languageId != null ? t.LanguageId == languageId : languageId == 1)
                    .Select(t => t.ShortText)
                    .FirstOrDefault() ?? t.ShortText,
                    LongText = t.TopicTranslations
                    .Where(t => languageId != null ? t.LanguageId == languageId : languageId == 1)
                    .Select(t => t.LongText)
                    .FirstOrDefault() ?? t.LongText
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Standard>> GetStandardTranslationsByLangId(long? languageId,long? organizationId,long? tableType,long? Id)
        {
            var list = await _context.Standards
                .Where(t => t.TopicId == Id)                
                .Select(s => new Standard
                {
                    Id = s.Id,
                    Code = s.Code,
                    TopicId = s.TopicId,
                    LanguageId = (long)languageId,
                    State = s.State,
                    ShortText = s.StandardTranslations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.ShortText)
                    .FirstOrDefault() ?? s.ShortText,
                    LongText = s.StandardTranslations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.LongText)
                    .FirstOrDefault() ?? s.LongText
                })
                .ToListAsync();
            return list;
        }
        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslations(long? languageId, long? organizationId, long? tableType, long? Id)
        {            
            var disreq = await _context.DisclosureRequirements
                .Where(t => t.StandardId == Id)                
                .Select(d => new DisclosureRequirement
                {
                    Id = d.Id,
                    Code = d.Code,
                    StandardId = d.StandardId,
                    LanguageId = (long)languageId,
                    State = d.State,
                    ShortText = d.DisclosureRequirementTranslations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.ShortText)
                    .FirstOrDefault(),
                    LongText = d.DisclosureRequirementTranslations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return disreq;
        }
        public async Task<IEnumerable<DataPointValue>> GetDatapointTranslations( long? tableType, long? Id, long? organizationId, long? languageId)
        {
            var datapoints = await _context.DataPointValue
                .Where(dr => dr.DisclosureRequirementId == Id)                
                .Select(dp => new DataPointValue
                {
                    Id = dp.Id,
                    Code = dp.Code,
                    LanguageId = (long)languageId,
                    State = dp.State,
                    ShortText = dp.DatapointValueTranslations
                    .Where(dt => dt.LanguageId == languageId)
                    .Select(dt => dt.ShortText)
                    .FirstOrDefault(),
                    LongText = dp.DatapointValueTranslations
                    .Where(dt => dt.LanguageId == languageId)
                    .Select(dt => dt.LongText)
                    .FirstOrDefault()
                })
                .ToListAsync();
            return datapoints;
        }
        public async Task<List<long>> GetDatapointsByHierarchyId(long? hierarchyId)
        {
            var datapointIds = await _context.Hierarchies
                    .AsNoTracking()
                    .Where(t => t.HierarchyId == hierarchyId)
                    .Select(dp => dp.DataPointValuesId) 
                    .ToListAsync();

            return datapointIds;
        }
        public async Task<List<long>> GetDatapointsLinkedToModelByOrganizationId(long? organizationId)
        {
            var datapointIds = await _context.DataModels
                .AsNoTracking()
                .Where(t => t.OrganizationId == organizationId && t.IsDefaultModel == false)
                .SelectMany(t => t.ModelDatapoints) 
                .Select(mdp => mdp.DatapointValuesId) 
                .ToListAsync();

            return datapointIds;
        }

        public async Task<IEnumerable<DataPointValue>> GetDatapoints(long? disReqId, long? organizationId)
        {
            var datapoints = await _context.DataPointValue
                .AsNoTracking()
                .Where(t => (t.OrganizationId == organizationId || t.OrganizationId == 1) && t.DisclosureRequirementId == disReqId && t.State == Domain.Enum.StateEnum.active)
                .ToListAsync();
            return datapoints;
        }

        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirements(long? standarddId)
        {
            var disreq = await _context.DisclosureRequirements
                .AsNoTracking()
                .Where(t => t.StandardId == standarddId)
                .ToListAsync();
            return disreq;
        }

        public async Task<IEnumerable<Standard>> GetStandards(long? topicId)
        {
            var standard = await _context.Standards
                .AsNoTracking()
                .Where(t => t.TopicId == topicId)
                .ToListAsync();
            return standard;
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            var topic = await _context.Topics
                .AsNoTracking()
                .ToListAsync();
            return topic;
        }

        public async Task<IEnumerable<Hierarchy>> GetHierarchyById(long? hierarchyId)
        {
            var hierarchies = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .ToListAsync();
            return hierarchies;
        }

        public async Task<long> GetHierarchyIdByUserIdOrgId(long userId, long orgId)
        {
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(a => a.CreatedBy == userId && a.OrganizationId == orgId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
            return hierarchyId;
        }

        public async Task<IEnumerable<Hierarchy>> GetHierarchies(long hierarchyId)
        {
            var hierarchies = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .ToListAsync();
            return hierarchies;
        }
        public async Task<IEnumerable<long>> GetRemainingDatapointsByOrganizationId(long organizationId)
        {
            var remainingDatapoints = new List<long>();
                
            var hierarchyId = await _context.OrganizationHeirarchies
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId)
                .Select(a => a.HierarchyId)
                .FirstOrDefaultAsync();
            var datapoints = await _context.Hierarchies
                .AsNoTracking()
                .Where(a => a.HierarchyId == hierarchyId)
                .Select(a => a.DataPointValuesId)
                .ToListAsync();
            var modelDatapoints = await _context.DataModels
                        .Where(dm => dm.OrganizationId == organizationId && dm.IsDefaultModel == false)
                        .SelectMany(dm => dm.ModelDatapoints)
                        .Select(mdp => mdp.DatapointValuesId).ToListAsync();
            remainingDatapoints = datapoints.Except(modelDatapoints).ToList();
            return remainingDatapoints;
        }
        
    }
}
