using AutoMapper;
using ESG.Application.Common.Interface.DataPoint;
using ESG.Application.Dto.DatapointValue;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DatapointRepo
{
    public class DatapointValueRepo : GenericRepository<DataPointValue>, IDatapointValueRepo
    {
        private readonly ApplicationDbContext _context;
        public DatapointValueRepo(ApplicationDbContext context): base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<long>> GetModelDatapointsByOrgId(long orgId)
        {
            var list = await _context.DataModels
                .AsNoTracking()
                .Where(x => x.OrganizationId == orgId)
                .SelectMany(a => a.ModelDatapoints.Select(md => md.DatapointValuesId))
                .ToListAsync();

            return list;
        }
        public async Task<IEnumerable<DataPointValue>> GetNamesForFilteredIds(IEnumerable<long> filteredIds)
        {
            var names = await _context.DataPointValue
                .Where(dp => filteredIds.Contains(dp.Id))
                .Select(dp => new DataPointValue
                {
                    Id = dp.Id,
                    Name = dp.Name,
                    IsNarrative = dp.IsNarrative,
                    DisclosureRequirementId = dp.DisclosureRequirementId
                })
                .ToListAsync();
            return names;
        }


    }
}
