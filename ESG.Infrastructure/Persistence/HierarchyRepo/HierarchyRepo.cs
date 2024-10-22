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
        public async Task<IEnumerable<long>> GetDatapointsByHierarchyId(long? hierarchyId)
        {
            var datapointIds = await _context.Hierarchies
                    .AsNoTracking()
                    .Where(t => t.HierarchyId == hierarchyId)
                    .Select(dp => dp.DataPointValuesId) 
                    .ToListAsync();

            return datapointIds;
        }
        public async Task<IEnumerable<DataPointValue>> GetDatapoints(long? disReqId, long? organizationId)
        {
            var datapoints = await _context.DataPointValue
                .AsNoTracking()
                .Where(t => (t.OrganizationId == organizationId || t.OrganizationId == 1) && t.DisclosureRequirementId == disReqId)
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
    }
}
