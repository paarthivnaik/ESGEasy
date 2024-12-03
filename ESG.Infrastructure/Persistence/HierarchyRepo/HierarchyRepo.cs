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
                //= await _context.Hierarchies
                //.AsNoTracking()
                //.Where(h => h.HierarchyId == _context.OrganizationHeirarchies
                //    .Where(oh => oh.OrganizationId == organizationId)
                //    .Select(oh => oh.HierarchyId)
                //    .FirstOrDefault())
                //.Select(h => h.DataPointValuesId)
                //.Except(
                //    _context.DataModels
                //        .Where(dm => dm.OrganizationId == organizationId && dm.IsDefaultModel == false)
                //        .SelectMany(dm => dm.ModelDatapoints)
                //        .Select(mdp => mdp.DatapointValuesId)
                //)
                //.ToListAsync();
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
