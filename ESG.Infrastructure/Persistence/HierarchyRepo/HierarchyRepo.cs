using ESG.Application.Common.Interface.Hierarchy;
using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Dto.Hierarchy;
using ESG.Domain.Entities;
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

        public async Task AddHierarchy(HierarchyCreateRequestDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            await AddHierarchyRecursive(request, null);
        }

        public async Task AddHierarchyRecursive(HierarchyCreateRequestDto request, long? parentId)
        {
            long nodeId = parentId.HasValue && parentId.Value != 0 ? parentId.Value : 0;
            //long? nodeId = parentId;
            long? dataPointValuesId = request.IsDataPoint ? request.Id : null;
            long? dimensionId = request.IsDataPoint ? null : request.Id == 0 ? null : request.Id;

            var hierarchy = new Hierarchy
            {
                NodeId = nodeId,
                DimensionId = dimensionId,
                DataPointValuesId = dataPointValuesId,
            };

            _context.Hierarchy.Add(hierarchy);
            await _context.SaveChangesAsync();

            nodeId = request.Id;
            if (request.Children != null && request.Children.Any())
            {
                foreach (var child in request.Children)
                {
                    await AddHierarchyRecursive(child, nodeId);
                }
            }
        }

        public async Task<IEnumerable<DataPointValues>> GetDatapoints(long? disReqId)
        {
            var datapoints = await _context.DataPointValues
                .AsNoTracking()
                .Where(t => t.DisclosureRequirementId == disReqId)
                .ToListAsync();
            return datapoints;
        }

        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirements(long? standarddId)
        {
            var disreq = await _context.DisclosureRequirement
                .AsNoTracking()
                .Where(t => t.StandardId == standarddId)
                .ToListAsync();
            return disreq;
        }

        public async Task<IEnumerable<Standard>> GetStandards(long? topicId)
        {
            var standard = await _context.Standard
                .AsNoTracking()
                .Where(t => t.TopicId == topicId)
                .ToListAsync();
            return standard;
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            var topic = await _context.Topic
                .AsNoTracking()
                .ToListAsync();
            return topic;
        }
    }
}
